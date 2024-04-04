

using PS_TEMA1.Model;
using PS_TEMA1.Model.Repositories;
using PS_TEMA1.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS_TEMA1.Presenter
{
    internal class OrganizatorPresenter
    {
        private IOrganizatorGui _organizatorGui;
        private UtilizatorRepository utilizatorRepository;
        private ParticipantiRepository participantiRepository;
        private PrezentareRepository prezentareRepository;

        public OrganizatorPresenter(IOrganizatorGui organizatorGui)
        {
            _organizatorGui = organizatorGui;
            utilizatorRepository = new UtilizatorRepository();
            participantiRepository = new ParticipantiRepository();
            prezentareRepository = new PrezentareRepository();
            _organizatorGui.GetTabelPrezentari().ItemsSource = prezentareRepository.GetPrezentari();
            _organizatorGui.GetTabelParticipanti().ItemsSource = participantiRepository.GetParticipanti();
            PrezentareSectiuneList();
            FilterList();
        }

        //Helper Methods
        //Helper Methods//
        private void PrezentareSectiuneList()
        {
            _organizatorGui.PrezentarecomboBox().ItemsSource = Enum.GetValues(typeof(Sectiune)).Cast<Sectiune>();
        }

        private void FilterList()
        {
            _organizatorGui.getFilterComboBox().ItemsSource = Enum.GetValues(typeof(Sectiune)).Cast<Sectiune>();
        }

        private Participant ValidParticipantData()
        {
            try
            {
                int id = _organizatorGui.getIdParticipant();
                String nume = _organizatorGui.getNumeParticipant();
                String email = _organizatorGui.getEmailParticipant();
                String telefon = _organizatorGui.getTelefonParticipant();
                String prezentare = _organizatorGui.getPrezentareParticipant();
                if(String.IsNullOrEmpty(nume) || String.IsNullOrEmpty(email) || String.IsNullOrEmpty(telefon) || String.IsNullOrEmpty(prezentare))
                {
                    throw new Exception("Toate campurile sunt obligatorii!");
                    return null;
                }
                Participant participant = new Participant();
                participant.Id = id;
                participant.Nume = nume;
                participant.Email = email;
                participant.Telefon = telefon;
                participant.IdPrezentare = Int32.Parse(prezentare);
                return participant;
            }
            catch (Exception ex)
            {
                _organizatorGui.showMessage("Eroare", ex.Message);
                return null;
            }
        }

        private Prezentare ValidPrezentareData()
        {
            try
            {
                int id = _organizatorGui.getIdPrezentare();
                String titlu = _organizatorGui.getTitluPrezentare();
                String autor = _organizatorGui.getAutorPrezentare();
                String descriere = _organizatorGui.getDescrierePrezentare();
                String data = _organizatorGui.getDataPrezentare();
                String ora = _organizatorGui.getOraPrezentare();
                Sectiune sectiune = _organizatorGui.getSectiunePrezentare();
                int conferinta = _organizatorGui.getConeferintaIdPrezentare();
                if (String.IsNullOrEmpty(titlu) || String.IsNullOrEmpty(autor) || String.IsNullOrEmpty(descriere) || String.IsNullOrEmpty(data) || String.IsNullOrEmpty(ora) || sectiune == null || conferinta == 0)
                {
                    throw new Exception("Toate campurile sunt obligatorii!");
                    return null;
                }
                Prezentare prezentare = new Prezentare();
                prezentare.Id = id;
                prezentare.Titlu = titlu;
                prezentare.Autor = autor;
                prezentare.Descriere = descriere;
                prezentare.Data = data;
                prezentare.Ora = ora;
                prezentare.Sectiune = sectiune;
                prezentare.Id_conferinta = conferinta;
                return prezentare;
            }
            catch (Exception ex)
            {
                _organizatorGui.showMessage("Eroare", ex.Message);
                return null;
            }
        }

        public void getParticipantsBySection() { }

        internal void filterSectiune()
        {
            Sectiune sectiune = _organizatorGui.getFilterSelected();
            if (sectiune == Sectiune.TOATE)
            {
                _organizatorGui.GetTabelParticipanti().ItemsSource = participantiRepository.GetParticipanti();
            }
            else
                _organizatorGui.GetTabelParticipanti().ItemsSource = participantiRepository.GetParticipantibySectiune(sectiune);
        }
        //Participant
        internal void selectParticipant()
        {
            if(_organizatorGui.GetTabelParticipanti().SelectedItem != null)
            {
                Participant selectedParticipant = _organizatorGui.GetTabelParticipanti().SelectedItem as Participant;
                _organizatorGui.setIdParticipant(selectedParticipant.Id);
                _organizatorGui.setNumeParticipant(selectedParticipant.Nume);
                _organizatorGui.setEmailParticipant(selectedParticipant.Email);
                _organizatorGui.setTelefonParticipant(selectedParticipant.Telefon);
                _organizatorGui.setPrezentareParticipant(selectedParticipant.IdPrezentare.ToString());

            }                       
        }

        internal void deleteParticipant()
        {
            try
            {
                if (_organizatorGui.GetTabelParticipanti().SelectedItem != null)
                {
                    Participant selectedParticipant = _organizatorGui.GetTabelParticipanti().SelectedItem as Participant;
                    participantiRepository.deleteParticipant(selectedParticipant);
                    participantiRepository.GetParticipanti();
                    _organizatorGui.GetTabelParticipanti().ItemsSource = participantiRepository.GetParticipanti();
                    _organizatorGui.showMessage(_organizatorGui.getNumeParticipant(), "Participantul a fost sters cu succes!");
                }
                {

                }
            }
            catch (Exception ex)
            {
                _organizatorGui.showMessage("Eroare", ex.Message);
            }
        }

        internal void updateParticipant()
        {
            Participant participant = ValidParticipantData();
            if (participant != null)
            {
                if(participantiRepository.updateParticipant(participant) == true)
                {
                    _organizatorGui.showMessage("Succes", "Participantul a fost actualizat cu succes!");
                    _organizatorGui.GetTabelParticipanti().ItemsSource = participantiRepository.GetParticipanti();
                }
                else
                {
                    _organizatorGui.showMessage("Error", "Nu s-a putut actualiza participantul!");
                }
            }          
        }

        internal void adaugaParticipant()
        {
            try
            {
                Participant participant = ValidParticipantData();
                if (participant != null)
                {
                    if (participantiRepository.addParticipant(participant) == true)
                    {
                        _organizatorGui.showMessage("Succes", "Participantul a fost adaugat cu succes!");
                        _organizatorGui.GetTabelParticipanti().ItemsSource = participantiRepository.GetParticipanti();
                    }
                    else
                    {
                        _organizatorGui.showMessage("Error", "Participantul exista deja in baza de date!");
                    }
                }

            }
            catch (Exception ex)
            {
                _organizatorGui.showMessage("Error", "Nu s-a putut adauga participantul!");
            }
        }

        internal void selectPrezentare()
        {
            if(_organizatorGui.GetTabelPrezentari().SelectedItem != null)
            {
                Prezentare selectedPrezentare = _organizatorGui.GetTabelPrezentari().SelectedItem as Prezentare;
                _organizatorGui.setIdPrezentare(selectedPrezentare.Id);
                _organizatorGui.setTitluPrezentare(selectedPrezentare.Titlu);
                _organizatorGui.setAutorPrezentare(selectedPrezentare.Autor);
                _organizatorGui.setDescrierePrezentare(selectedPrezentare.Descriere);
                _organizatorGui.setDataPrezentare(selectedPrezentare.Data);
                _organizatorGui.setOraPrezentare(selectedPrezentare.Ora);
                _organizatorGui.setSectiunePrezentare(selectedPrezentare.Sectiune);
                _organizatorGui.setConferintaIdPrezentare(selectedPrezentare.Id_conferinta);
            }
        }

        internal void deletePrezentare()
        {
            try
            {
                if (_organizatorGui.GetTabelPrezentari().SelectedItem != null)
                {
                    Prezentare selectedPrezentare = _organizatorGui.GetTabelPrezentari().SelectedItem as Prezentare;
                    prezentareRepository.DeletePrezentare(selectedPrezentare.Id);
                    prezentareRepository.GetPrezentari();
                    _organizatorGui.GetTabelPrezentari().ItemsSource = prezentareRepository.GetPrezentari();
                    _organizatorGui.showMessage(_organizatorGui.getTitluPrezentare(), "Prezentarea a fost stearsa cu succes!");
                }
            }
            catch (Exception ex)
            {
                _organizatorGui.showMessage("Eroare", ex.Message);
            }
        }
               
        internal void adaugaPrezentare()
        {
            try
            {
                Prezentare prezentare = ValidPrezentareData();
                if (prezentare != null)
                {
                    if(prezentareRepository.AddPrezentare(prezentare) == true)
                    {
                        _organizatorGui.showMessage("Succes", "Prezentarea a fost adaugata cu succes!");
                        _organizatorGui.GetTabelPrezentari().ItemsSource = prezentareRepository.GetPrezentari();
                    }
                    else
                    {
                        _organizatorGui.showMessage("Error", "Prezentarea exista deja in baza de date!");
                    }
                }
            }
            catch (Exception ex)
            {
                _organizatorGui.showMessage("Error", "Nu s-a putut adauga prezentarea!");
            }            
        }

        internal void updatePrezentare()
        {
            Prezentare prezentare = ValidPrezentareData();
            if (prezentare != null)
            {
                if (prezentareRepository.UpdatePrezentare(prezentare) == true)
                {
                    _organizatorGui.showMessage("Succes", "Prezentarea a fost actualizata cu succes!");
                    _organizatorGui.GetTabelPrezentari().ItemsSource = prezentareRepository.GetPrezentari();
                }
                else
                {
                    _organizatorGui.showMessage("Error", "Nu s-a putut actualiza prezentarea!");
                }
            }
        }

        
    }
}

