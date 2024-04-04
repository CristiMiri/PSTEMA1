using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS_TEMA1.View.Interfaces
{
    internal interface ILoginGui : IGUI
    {
        String getEmail();
        void setEmail(String email);
        String getPassword();
        void setPassword(String password);
    }
}
