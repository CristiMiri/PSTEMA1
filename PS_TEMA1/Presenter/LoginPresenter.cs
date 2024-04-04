using PS_TEMA1.Model.Repositories;
using PS_TEMA1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PS_TEMA1.View.Pages;

namespace PS_TEMA1.Presenter
{
    internal class LoginPresenter
    {
        
        private LoginPage _loginPage;
        private UtilizatorRepository _utilizatorRepository = new UtilizatorRepository();
        private String loginType;
        public LoginPresenter(LoginPage loginPage)
        {
            this._loginPage = loginPage;
            this._utilizatorRepository = new UtilizatorRepository();
        }

        private Utilizator validData()
        {
            string email = this._loginPage.getEmail();
            string password = this._loginPage.getPassword();
            if (email.Length < 3 && !email.Contains("@") && email.Length > 30)
            {
                this._loginPage.showMessage("Invalid email", "Invalid email");
                return null;
            }
            else if (password.Length < 3)
            {
                this._loginPage.showMessage("Password too short", "Password too short");
                return null;
            }
            return new Utilizator(email, password);
        }

        public void login()
        {
            Utilizator utilizator = validData();
            Utilizator utilizatorLogat = this._utilizatorRepository.
                GetUtilizatorbyEmailandParola(this._loginPage.getEmail(), this._loginPage.getPassword());

            Console.WriteLine(utilizatorLogat);

            if (utilizator != null)
            {
                switch (utilizatorLogat.UserType)
                {
                    case UserType.ADMINISTRATOR:
                        this.loginType = "admin";
                        break;
                    case UserType.PARTICIPANT:
                        this.loginType = "participant";
                        break;
                    case UserType.ORGANIZATOR:
                        this.loginType = "organizator";
                        break;
                }
            }
            else
            {
                this._loginPage.showMessage("Login failed", "Invalid username or password");
            }
        }

        internal string getUserType()
        {
            return this.loginType;
        }
    }
}
