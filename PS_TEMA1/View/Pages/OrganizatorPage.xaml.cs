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
    /// Interaction logic for OrganizatorPage.xaml
    /// </summary>
    public partial class OrganizatorPage : Page, IOrganizatorGui
    {
        private OrganizatorPresenter _organizatorPresenter;
        private Action<string> _callback;

        public Action<string> Callback { get => _callback; set => _callback = value; }
       
        public OrganizatorPage()
        {
            InitializeComponent();
            _organizatorPresenter = new OrganizatorPresenter(this);            
        }


        //Event Handlers//
        private void UpdateParticipantButton_Click(object sender, RoutedEventArgs e)
        {
            _organizatorPresenter.updateParticipant();
        }

        private void AdaugaPrezentareButton_Click(object sender, RoutedEventArgs e)
        {
            _organizatorPresenter.adaugaPrezentare();
        }

        private void UpdatePrezentareButton_Click(object sender, RoutedEventArgs e)
        {
            _organizatorPresenter.updatePrezentare();
        }

        private void AdaugaParticipantButton_Click(object sender, RoutedEventArgs e)
        {
            _organizatorPresenter.adaugaParticipant();
        }

        private void SelectParticipantButton_Click(object sender, RoutedEventArgs e)
        {
            _organizatorPresenter.selectParticipant();
            ParticipantiExpander.IsExpanded = true;
        }

        private void SelectPrezentareButton_Click(object sender, RoutedEventArgs e)
        {
            _organizatorPresenter.selectPrezentare();
            PrezentariExpander.IsExpanded = true;
        }

        private void DeletePrezentareButton_Click(object sender, RoutedEventArgs e)
        {
            _organizatorPresenter.deletePrezentare();
        }

        private void DeleteParticipantButton_Click(object sender, RoutedEventArgs e)
        {
            _organizatorPresenter.deleteParticipant();
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            _organizatorPresenter.filterSectiune();
        }


        //IOrganizatorGui
        //Participant
        public int getIdParticipant()
        {
            return int.Parse(IdParticipant.Text);
        }

        public string getNumeParticipant()
        {
            return NumeTextBox.Text;
        }

        public string getEmailParticipant()
        {
            return EmailTextBox.Text;
        }

        public string getTelefonParticipant()
        {
            return TelefonTextBox.Text;
        }

        public string getPrezentareParticipant()
        {
            return IdPrezentareTextBox.Text;
        }

        public void setIdParticipant(int idParticipant)
        {
            IdParticipant.Text = idParticipant.ToString();
        }

        public void setNumeParticipant(string numeParticipant)
        {
            NumeTextBox.Text = numeParticipant;
        }

        public void setEmailParticipant(string emailParticipant)
        {
            EmailTextBox.Text = emailParticipant;
        }

        public void setTelefonParticipant(string telefonParticipant)
        {
            TelefonTextBox.Text = telefonParticipant;
        }

        public void setPrezentareParticipant(string prezentareParticipant)
        {
            IdPrezentareTextBox.Text = prezentareParticipant;
        }

        //Prezentare
        public int getIdPrezentare()
        {
            return int.Parse(IdPrezentareTextBox.Text);
        }
        public string getTitluPrezentare()
        {
            return TitluTextBox.Text;
        }

        public string getAutorPrezentare()
        {
            return AutorTextBox.Text;
        }

        string IOrganizatorGui.getDescrierePrezentare()
        {
            return DescriereTextBox.Text;
        }

        string IOrganizatorGui.getDataPrezentare()
        {
            return DataDatePicker.Text;
        }

        string IOrganizatorGui.getOraPrezentare()
        {
            return OraTextBox.Text;
        }

        Sectiune IOrganizatorGui.getSectiunePrezentare()
        {
            return (Sectiune)ComboBoxSectiuneAdministrare.SelectedItem;
        }

        int IOrganizatorGui.getConeferintaIdPrezentare()
        {
            return int.Parse(IdConferintaTextBox.Text);
        }

        void IOrganizatorGui.setIdPrezentare(int idPrezentare)
        {
            IdPrezentareTextBox.Text = idPrezentare.ToString();
        }

        void IOrganizatorGui.setTitluPrezentare(string titluPrezentare)
        {
            TitluTextBox.Text = titluPrezentare;
        }

        void IOrganizatorGui.setAutorPrezentare(string autorPrezentare)
        {
            AutorTextBox.Text = autorPrezentare;
        }

        void IOrganizatorGui.setDescrierePrezentare(string descrierePrezentare)
        {
            DescriereTextBox.Text = descrierePrezentare;
        }

        void IOrganizatorGui.setDataPrezentare(string dataPrezentare)
        {
            DataDatePicker.Text = dataPrezentare;
        }

        void IOrganizatorGui.setOraPrezentare(string oraPrezentare)
        {
            OraTextBox.Text = oraPrezentare;
        }

        void IOrganizatorGui.setSectiunePrezentare(Sectiune sectiunePrezentare)
        {
            ComboBoxSectiuneAdministrare.SelectedItem = sectiunePrezentare;
        }

        void IOrganizatorGui.setConferintaIdPrezentare(int conferintaIdPrezentare)
        {
            IdConferintaTextBox.Text = conferintaIdPrezentare.ToString();
        }

        public DataGrid GetTabelPrezentari()
        {
            return TabelPrezentari;
        }

        public DataGrid GetTabelParticipanti()
        {
            return TabelParticipanti;
        }

        public Sectiune getFilterSelected()
        {
            return (Sectiune)Enum.Parse(typeof(Sectiune), ComboBoxSectiune.SelectedValue.ToString());
        }

        public void setFilerSelected(Sectiune sectiune)
        {
            ComboBoxSectiune.SelectedItem = sectiune;
        }

        ComboBox IOrganizatorGui.getFilterComboBox()
        {
            return ComboBoxSectiune;
        }

        ComboBox IOrganizatorGui.PrezentarecomboBox()
        {
            return ComboBoxSectiuneAdministrare;
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
