using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
//using System.Text.Json;
//using System.Text.Json.Nodes;

//ask keith
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static OOD_Project.Landing_Page;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

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
            string apiKey = "31ichicpcbi7";  //add your api key here

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


        private void btncreatebird_Click(object sender, RoutedEventArgs e)
        {

        }

        
    }

}

