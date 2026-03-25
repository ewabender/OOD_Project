using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OOD_Project
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, RoutedEventArgs e)
        {

            string userinput = tbxpasswd.Password;
            //user is ewabender
            //password is munchies
            //if user succesful
            if (userinput.ToString() == "munchies") 
            {
                LandingWindow create = new LandingWindow();
                create.Owner = this;
                create.ShowDialog();

            }
        }
    }
}
