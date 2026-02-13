using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using static OOD_Project.UserBird;

namespace OOD_Project
{
    /// <summary>
    /// Interaction logic for Landing_Page.xaml
    /// </summary>
    public partial class Landing_Page : Page
    {
        List<JsonBird> AllBirdsJ = new List<JsonBird>();
        List<ShowKeithBird> AllBirdsU = new List<ShowKeithBird>();

        public Landing_Page()
        {
            InitializeComponent();

            //these 2 lines are solely here to show that radio btns are working
            ShowKeithBird b1 = new ShowKeithBird() { comName = "Berd", sciName = "Stinky Stinky", howMany = 2 };
            AllBirdsU.Add(b1);
        }

        async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            string apiKey = "31ichicpcbi7";

            EbirdClient client = new EbirdClient(apiKey);

            string json = await client.GetRecentObservations("IE"); // IE = Ireland


            AllBirdsJ = JsonSerializer.Deserialize<List<JsonBird>>(json);

            rdAll.IsChecked = true;
        }
        //Display certain properties
        private void lbshowbird_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //selects the birds object 
            JsonBird Bird = lbshowbird.SelectedItem as JsonBird;

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
            //delete an entry here

        }

        private void rdAll_Checked(object sender, RoutedEventArgs e, IEnumerable<JsonBird> allBirdsJ)
        {
            var concatBird = allBirdsJ.Concat(AllBirdsU);
            List<JsonBird> birds  = concatBird.ToList();
            birds.Sort();
            lbshowbird.ItemsSource = birds;
        }

        private void rdAPI_Checked(object sender, RoutedEventArgs e)
        {
            lbshowbird.ItemsSource = AllBirdsJ;
        }

        private void rdUserMade_Checked(object sender, RoutedEventArgs e)
        {
            lbshowbird.ItemsSource = AllBirdsU;

        }
    }

}

