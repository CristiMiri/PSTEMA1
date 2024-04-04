using PS_TEMA1.Presenter;
using PS_TEMA1.View.Interfaces;
using PS_TEMA1.View.Pages;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PS_TEMA1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainGui
    {
        private MainPresenter _mainPresenter;
        public MainWindow()
        {
            InitializeComponent();
            //mainFrame.Content = new HomePage();//
            mainFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            _mainPresenter = new MainPresenter(this);

            //mainFrame.Content = new AdminPage(_mainPresenter.ChangePage);
            OrganizatorPage organizatorPage = new OrganizatorPage();
            organizatorPage.Callback = _mainPresenter.ChangePage;
            UtilizatorPage utilizatorPage = new UtilizatorPage();
            utilizatorPage.SetCallback(_mainPresenter.ChangePage);
            mainFrame.Content = new HomePage();


            //HideHeader();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //Console.WriteLine("Hello World!");
            //Repository repository = new Repository();
            ////SELECT * FROM public."Tester";
            ////print all the data from the table
            //DataTable dataTable =repository.ExecuteQuery("SELECT * FROM public.\"Tester\";");
            //foreach (DataRow row in dataTable.Rows)
            //{
            //    Console.WriteLine(row["id"]);
            //}
            //MessageBox.Show("Hello World!");

            //main.Content = new LoginPage();

            //UtilizatorDialog utilizatorDialog = new UtilizatorDialog();
            //utilizatorDialog.ShowDialog();

        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            _mainPresenter.ShowLoginPage();
        }
        private void Foms_Click(object sender, RoutedEventArgs e)
        {
            //UtilizatorDialog utilizatorDialog = new UtilizatorDialog();
            //PrezentareDialog prezentareDialog = new PrezentareDialog();
            //ConferintaDialog conferintaDialog = new ConferintaDialog();
            //utilizatorDialog.ShowDialog();
            //prezentareDialog.ShowDialog();
            //conferintaDialog.ShowDialog();
            mainFrame.Content = new HomePage();
        }

        private void main_Navigated(object sender, NavigationEventArgs e)
        {

        }

        public Frame GetFrame()
        {
            return mainFrame;
        }

        public void SetFrameContent(Page page)
        {
            mainFrame.Content = page;
        }

        public void ShowHeader()
        {
            Header.Visibility = Visibility.Visible;
        }

        public void HideHeader()
        {
            //loginButton.Visibility = Visibility.Collapsed;
            Header.Visibility = Visibility.Collapsed;
        }
    }
}