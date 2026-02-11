using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
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
using System.Xml.Linq;

namespace OOD_Project_v2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<JsonBird> allBirds = new List<JsonBird>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string apiKey = "31ichicpcbi7";  //add your api key here

            var client = new EBirdClient(apiKey);

            string json = await client.GetRecentObservations("IE"); // IE = Ireland


            allBirds = JsonSerializer.Deserialize<List<JsonBird>>(json);

            lbxBirds.ItemsSource = allBirds;
        }


        private void lbxBirds_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //selects the  object 
            JsonBird Bird = lbxBirds.SelectedItem as JsonBird;
            //this thing makes the albums display alongside the band
            if (Bird != null)
            {

                //this displays info about the bird
                tbxBird.Text = string.Format($"Common Name: {Bird.comName} \nScientific Name: {Bird.sciName} \nLocation: {Bird.locName} \nWhen: {Bird.obsDt} \nHow many: {Bird.howMany}");
            }
        }
    }//end of MainWindow class


   
    
}
