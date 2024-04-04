using PS_TEMA1.Model;
using PS_TEMA1.Presenter;
using PS_TEMA1.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page, IHomeGui
    {
        private HomePresenter presenter;
        public HomePage()
        {
            InitializeComponent();
            presenter = new HomePresenter(this);
            this.FilterList();
        }


        public string getEmail()
        {
            return txtEmail.Text;
        }

        public string getNume()
        {
            return txtNume.Text;
        }

        public string getPrezentareSelectata()
        {
            return cmbPrezentare.SelectedItem.ToString();
        }
    
        public string getTelefon()
        {
            return txtTelefon.Text;
        }

        public void setEmail(string email)
        {
            txtEmail.Text = email;
        }

        public void setNume(string nume)
        {
            txtNume.Text = nume;
        }

        public void setPrezentareSelectata(string prezentare)
        {
            cmbPrezentare.SelectedItem = prezentare;
        }

        public void setPrezentariSelection(List<string> prezentari)
        {
            cmbPrezentare.ItemsSource = prezentari;
        }

        public void setTelefon(string telefon)
        {
            txtTelefon.Text = telefon;
        }

        public void showMessage(string title, string message)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Information);
        }
      
        public DataGrid getTabelConferinte()
        {
            return this.TabelConferinte;
        }
        private Action<string> _callback;
        private object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Sectiune sectiune)
            {
                switch (sectiune)
                {
                    case Sectiune.STIINTE:
                        return "Stiinte";
                    case Sectiune.TEHNOLOGIE:
                        return "Tehnologie";
                    case Sectiune.MEDICINA:
                        return "Medicina";
                    case Sectiune.ARTA:
                        return "Arta";
                    case Sectiune.SPORT:
                        return "Sport";
                    default:
                        return string.Empty;
                }
            }
            return string.Empty;
        }


        public Sectiune getFilterSelected()
        {
            return (Sectiune)cmbSectiune.SelectedItem;
        }

        public void setFilterSelected(Sectiune sectiune)
        {
            cmbSectiune.SelectedItem = sectiune;
        }

        public void FilterList()
        {
            cmbSectiune.ItemsSource = Enum.GetValues(typeof(Sectiune)).Cast<Sectiune>();            
        }

        //Event Handlers
        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            presenter.inscriereConferinta();
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            presenter.cautareSectiune();
        }

        internal void SetCallback(Action<string> changePage)
        {
            _callback = changePage;
        }
    }
}
