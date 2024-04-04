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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page, ILoginGui
    {

        private LoginPresenter _loginPresenter;
        private Action<String> callback;
        private string loginType;
        public LoginPage(Action<String> callback)
        {
            InitializeComponent();
            this._loginPresenter = new LoginPresenter(this);
            this.callback = callback;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            this._loginPresenter.login();
            this.callback?.Invoke(this._loginPresenter.getUserType());
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.callback?.Invoke("home");
        }

        // ILoginGui interface 
        public string getEmail()
        {
            return this.txtEmail.Text;
        }
        public void setEmail(String email)
        {
            this.txtEmail.Text = email;
        }

        public string getPassword()
        {
            return this.txtPassword.Password;
        }

        public void setPassword(String password)
        {
            this.txtPassword.Password = password;
        }

        public void showMessage(string title, string message)
        {
            MessageBox.Show(message, title);
        }


    }
}
