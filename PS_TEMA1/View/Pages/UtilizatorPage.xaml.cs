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
    /// Interaction logic for UtilizatorPage.xaml
    /// </summary>
    public partial class UtilizatorPage : Page, IUtilizatorGui
    {
        private UtilizatorPresenter _utilizatorPresenter;
        private Action<string> _callback;

        public void SetCallback(Action<string> callback)
        {
            _callback = callback;
        }

        public UtilizatorPage()
        {
            InitializeComponent();
            _utilizatorPresenter = new UtilizatorPresenter(this);
        }

        public DataGrid getTabelConferinte()
        {
            return this.TabelConferinte;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            _callback?.Invoke("home");
        }
    }
}
