using System;
using System.Collections.Generic;
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
        List<JsonBird> AllBirds = new List<JsonBird>();

        public Landing_Page()
        {
            InitializeComponent();
        }

     
        async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            string apiKey = "31ichicpcbi7";  

            EbirdClient client = new EbirdClient(apiKey);

            string json = await client.GetRecentObservations("IE"); // IE = Ireland


            AllBirds = JsonSerializer.Deserialize<List<JsonBird>>(json);

            lbshowbird.ItemsSource = AllBirds;
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

        
    }

}

