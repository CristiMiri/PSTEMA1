using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PS_TEMA1.View.Interfaces
{
    internal interface IGUI
    {
        void showMessage(string title, string message)
        {
            MessageBox.Show(message, title);
        }
    }
}
