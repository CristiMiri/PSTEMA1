using PS_TEMA1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PS_TEMA1.View.Interfaces
{
    internal interface IAdminGui : IGUI
    {
        DataGrid getDataGrid();
        void setDataGridItemsSource(List<Utilizator> utilizators);
        int getUtilizatorId();
        void setUtilizatorId(int id);
        string getUtilizatorNume();
        void setUtilizatorNume(string nume);
        string getUtilizatorEmail();
        void setUtilizatorEmail(string email);
        string getUtilizatorParola();
        void setUtilizatorParola(string parola);
        UserType getUtilizatorType();
        void setUtilizatorType(UserType userType);
        string getUtilizatorTelefon();
        void setUtilizatorTelefon(string telefon);
        void clearFields();
    }
}
