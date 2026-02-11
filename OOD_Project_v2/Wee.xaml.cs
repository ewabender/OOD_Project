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
using static System.Net.WebRequestMethods;

namespace OOD_Project_v2
{
    /// <summary>
    /// Interaction logic for Wee.xaml
    /// </summary>
    public partial class Wee : Page
    {
        public Wee()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Source - https://stackoverflow.com/a/20807014
            // Posted by Jake, modified by community. See post 'Timeline' for change history
            // Retrieved 2026-02-11, License - CC BY-SA 4.0

            _Nav1.Navigate(new Page());
            this.NavigationService.Navigate(new Uri("Woo.xaml", UriKind.Relative));
        }
    }
}
