using PS_TEMA1.Model;
using PS_TEMA1.Presenter;
using PS_TEMA1.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PS_TEMA1.View.Pages
{
    /// <summary>
    /// Interaction logic for AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page, IAdminGui
    {
        private AdminPresenter _adminPresenter;
        private Action<string> _callback;

        public AdminPage()
        {
            InitializeComponent();
            _adminPresenter = new AdminPresenter(this);            
            UserTypeComboBoxItems();
        }

        public void HideForm()
        {
            throw new NotImplementedException();
        }        

        public DataGrid getDataGrid()
        {
            return TabelUtilizatori;
        }
        public int getUtilizatorId()
        {
            return !string.IsNullOrEmpty(IdTextBox.Text) ? Convert.ToInt32(IdTextBox.Text) : 0;
        }

        public void setUtilizatorId(int id)
        {
            IdTextBox.Text = id.ToString();
        }

        public string getUtilizatorNume()
        {
            return NumeTextBox.Text;
        }

        public void setUtilizatorNume(string nume)
        {
            NumeTextBox.Text = nume;
        }

        public string getUtilizatorEmail()
        {
            return EmailTextBox.Text;
        }

        public void setUtilizatorEmail(string email)
        {
            EmailTextBox.Text = email;
        }

        public string getUtilizatorParola()
        {
            return ParolaTextBox.Text;
        }

        public void setUtilizatorParola(string parola)
        {
            ParolaTextBox.Text = parola;
        }

        public void UserTypeComboBoxItems()
        {
            UserTypeComboBox.ItemsSource = Enum.GetValues(typeof(UserType)).Cast<UserType>();
        }

        public UserType getUtilizatorType()
        {
            return (UserType)UserTypeComboBox.SelectedItem;
        }

        public void setUtilizatorType(UserType userType)
        {
            UserTypeComboBox.SelectedItem = userType;
        }

        public string getUtilizatorTelefon()
        {
            return TelefonTextBox.Text;
        }

        public void setUtilizatorTelefon(string telefon)
        {
            TelefonTextBox.Text = telefon;
        }

        public void clearFields()
        {
            NumeTextBox.Text = "";
            EmailTextBox.Text = "";
            ParolaTextBox.Text = "";
            UserTypeComboBox.SelectedItem = null;
            TelefonTextBox.Text = "";
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            _adminPresenter.DeleteUser();
        }

        private void CreateUserButton_Click(object sender, RoutedEventArgs e)
        {
            _adminPresenter.CreateUser();
        }

        void IAdminGui.setDataGridItemsSource(List<Utilizator> utilizators)
        {
            TabelUtilizatori.ItemsSource = utilizators;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            _adminPresenter.UpdateUser();
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            _adminPresenter.SetFormFields();
            Administrare.IsExpanded = true;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            _callback?.Invoke("home");
        }

        internal void SetCallback(Action<string> changePage)
        {
            _callback = changePage;
        }
    }
}
