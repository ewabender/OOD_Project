using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace OOD_Project
{
    /// <summary>
    /// Interaction logic for Landing_Page.xaml
    /// </summary>
    public partial class Landing_Page : Page
    {
        List<Bird> AllBirdsJ = new List<Bird>();
        List<Bird> AllBirdsU = new List<Bird>();
        List<Bird> AllBirds = new List<Bird>();

        public Landing_Page()
        {
            InitializeComponent();

            
            Bird b1 = new Bird() { comName = "Berd", sciName = "Stinky Stinky", howMany = 42 };
            AllBirds.Add(b1);

            Bird b2 = new Bird() { comName = "Elsa", sciName = "Frozen Frozen", howMany = 62 };
            AllBirds.Add(b2);
        }

        async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            string apiKey = "31ichicpcbi7";

            EbirdClient client = new EbirdClient(apiKey);

            string json = await client.GetRecentObservations("IE"); // IE = Ireland


            AllBirds = JsonSerializer.Deserialize<List<Bird>>(json);

            rdAll.IsChecked = true;
        }
        //Display certain properties
        private void lbshowbird_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //selects the birds object 
            Bird Bird = lbshowbird.SelectedItem as Bird;

            //if the thing ain't null 
            if (Bird != null)
            {

                //this displays info about the bird
                tbdescribebird.Text = string.Format($"Common Name: {Bird.comName} \nScientific Name: {Bird.sciName} \nLocation: {Bird.locName} \nWhen: {Bird.obsDt} \nHow many: {Bird.howMany}");
            }


        }

        //implement a functionality when you can move between pages
        private void btncreatebird_Click(object sender, RoutedEventArgs e)
        {
            //Source - https://stackoverflow.com/a/20807014
            // Posted by Jake, modified by community. See post 'Timeline' for change history
            // Retrieved 2026-02-11, License - CC BY-SA 4.0

            Landing_Pg.Navigate(new Page());
            this.NavigationService.Navigate(new Uri("Create_Bird.xaml", UriKind.Relative));
        }

        private void btndelbird_Click(object sender, RoutedEventArgs e)
        {
            Bird jsonBird = lbshowbird.SelectedItem as Bird;

            if ( jsonBird != null)
            {
                AllBirds.Remove(jsonBird);
            }
        }

        private void rdAll_Checked(object sender, RoutedEventArgs e)
        {
            //var concatBird = AllBirdsU.Concat(AllBirdsJ);
            //List<Bird> birds = concatBird.ToList();
            //birds.Sort();
            lbshowbird.ItemsSource = AllBirds;
        }

        private void rdAPI_Checked(object sender, RoutedEventArgs e)
        {
            AllBirds.Sort();
            lbshowbird.ItemsSource = AllBirds;
        }

        private void rdUserMade_Checked(object sender, RoutedEventArgs e)
        {
            AllBirds.Sort();
            lbshowbird.ItemsSource = AllBirds;

        }
    }

}

