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
        List<Ree> Oldies = new List<Ree>();
        List<Dingus> Whowhat = new List<Dingus>();
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

        private void _Nav1_Initialized(object sender, EventArgs e)
        {
            Ree b1 = new Ree() { bah = "The Foo Fighters", wah = "Dave Grohl, Nate Mendel, Pat Smear, Taylor Hawkins, Chris Shifflett, Rami Jafee" };
            Ree b2 = new Ree() { bah = "The Rolling Stones", wah = "Mick Jagger, Ian Stewart, Dick Taylor, Bill Wyman, Mick Taylor" };

            Dingus d1 = new Dingus() { bah = "Markiplier", wah = "Horror Games yee" };
            Dingus d2 = new Dingus() { bah = "PiewDiePie", wah = "Gamer words + art :)" };


            Oldies.Add(b1);
            Oldies.Add(b2);

            Whowhat.Add(d1);
            Whowhat.Add(d2);
           rdbchicken.IsChecked=true;


        }

        private void rdbchicken_Checked(object sender, RoutedEventArgs e)
        {
            lbxcarrot.ItemsSource = Oldies;
            lbxcarrot.ItemsSource = Whowhat;
        }

        private void rdbrex_Checked(object sender, RoutedEventArgs e)
        {

            lbxcarrot.ItemsSource = Oldies;
        }

        private void rbtRee_Checked(object sender, RoutedEventArgs e)
        {
            lbxcarrot.ItemsSource = Whowhat;
        }
    }
}
