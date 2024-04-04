using PS_TEMA1.Model.Repositories;
using PS_TEMA1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PS_TEMA1.View.Interfaces;
using System.Windows.Controls;

namespace PS_TEMA1.Presenter
{
    internal class AdminPresenter
    {
        private IAdminGui _adminGui;
        private UtilizatorRepository utilizatorRepository;

        public AdminPresenter(IAdminGui adminGui)
        {
            _adminGui = adminGui;
            utilizatorRepository = new UtilizatorRepository();
            List<Utilizator> utilizators = utilizatorRepository.GetUtilizatori();
            DataGrid dataGrid = _adminGui.getDataGrid();
            dataGrid.ItemsSource = utilizators;
        }

        internal void CreateUser()
        {
            try
            {
                Utilizator utilizator = validData();
                if (utilizator != null)
                {

                    if (utilizatorRepository.addUtilizator(utilizator) == true)
                    {
                        _adminGui.showMessage("Succes", "Utilizatorul a fost adaugat cu succes!");
                        List<Utilizator> utilizators = utilizatorRepository.GetUtilizatori();
                        _adminGui.setDataGridItemsSource(utilizators);
                    }
                    else
                    {
                        _adminGui.showMessage("Error", "Utilizatorul exista deja in baza de date!");
                    }
                }
            }
            catch (Exception e)
            {
                _adminGui.showMessage("Error", "Nu s-a putut adauga utilizatorul!");
            }
        }

        public void DeleteUser()
        {

            if (_adminGui.getDataGrid().SelectedItem != null)
            {
                Utilizator selectedUtilizator = _adminGui.getDataGrid().SelectedItem as Utilizator;
                if (selectedUtilizator != null)
                {
                    utilizatorRepository.deleteUtilizator(selectedUtilizator.Id);
                    utilizatorRepository.GetUtilizatori();
                    _adminGui.setDataGridItemsSource(utilizatorRepository.GetUtilizatori());
                    _adminGui.showMessage(_adminGui.getUtilizatorNume(), "Utilizatorul a fost sters cu succes!");
                }
            }
        }

        private Utilizator validData()
        {
            String name = _adminGui.getUtilizatorNume();
            String email = _adminGui.getUtilizatorEmail();
            String parola = _adminGui.getUtilizatorParola();
            String telefon = _adminGui.getUtilizatorTelefon();
            UserType user_Type = _adminGui.getUtilizatorType();
            int id = _adminGui.getUtilizatorId();
            if (id < 0)
            {
                _adminGui.showMessage("Error", "Id-ul nu poate fi negativ!");
                return null;
            }
            if (String.IsNullOrEmpty(name))
            {
                _adminGui.showMessage("Error", "Numele este obligatoriu!");
                return null;
            }
            if (String.IsNullOrEmpty(email))
            {
                _adminGui.showMessage("Error", "Email-ul este obligatoriu!");
                return null;
            }
            if (String.IsNullOrEmpty(parola))
            {
                _adminGui.showMessage("Error", "Parola este obligatorie!");
                return null;
            }
            if (String.IsNullOrEmpty(telefon))
            {
                _adminGui.showMessage("Error", "Telefonul este obligatoriu!");
                return null;
            }
            if (user_Type == null)
            {
                _adminGui.showMessage("Error", "Tipul utilizatorului este obligatoriu!");
                return null;
            }
            return new Utilizator(id, name, email, parola, user_Type, telefon);

        }

        public void UpdateUser()
        {
            Utilizator utilizator = validData();

            if (utilizator != null)
            {
                if (utilizatorRepository.updateUtilizator(utilizator) == true)
                {
                    _adminGui.showMessage("Succes", "Utilizatorul a fost actualizat cu succes!");
                    List<Utilizator> utilizators = utilizatorRepository.GetUtilizatori();
                    _adminGui.setDataGridItemsSource(utilizators);
                }
                else
                {
                    _adminGui.showMessage("Error", "Nu s-a putut actualiza utilizatorul!");
                }
            }
        }

        internal void SetFormFields()
        {
            if (_adminGui.getDataGrid().SelectedItem != null)
            {
                Utilizator selectedUtilizator = _adminGui.getDataGrid().SelectedItem as Utilizator;
                _adminGui.setUtilizatorId(selectedUtilizator.Id);
                _adminGui.setUtilizatorEmail(selectedUtilizator.Email);
                _adminGui.setUtilizatorNume(selectedUtilizator.Nume);
                _adminGui.setUtilizatorParola(selectedUtilizator.Parola);
                _adminGui.setUtilizatorTelefon(selectedUtilizator.Telefon);
                _adminGui.setUtilizatorType(selectedUtilizator.UserType);


            }
        }

    }
}
