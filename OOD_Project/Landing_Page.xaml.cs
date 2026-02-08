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

namespace OOD_Project
{
    /// <summary>
    /// Interaction logic for Landing_Page.xaml
    /// </summary>
    public partial class Landing_Page : Page
    {
        List<Bird> Birds = new List<Bird>();
        public Landing_Page()
        {
            InitializeComponent();
        }

        public class EBirdClient
        {
            private readonly HttpClient _httpClient;
            public EBirdClient(string apiKey)
            {
                _httpClient = new HttpClient();
                _httpClient.BaseAddress = new Uri("https://api.ebird.org/v2/");
                _httpClient.DefaultRequestHeaders.Add("x-ebirdapitoken", apiKey);
            }

            public async Task<string> GetRecentObservations(string regionCode, int maxResults = 50)
            {
                string endpoint = $"data/obs/{regionCode}/recent?maxResults={maxResults}";
                var response = await _httpClient.GetAsync(endpoint);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }

            //how do I create objects from JSON + isolate specific thing and shove it to the bits of the part of the object
            //ask keith


            static async Task Main() // initiates api
            {
                string apiKey = "31ichicpcbi7";

                var client = new EBirdClient(apiKey);
                string json = await client.GetRecentObservations("IE"); // IE = Ireland

            }

            //static string PrettyPrintJson(string json)
            //{
            //    var node = JsonNode.Parse(json);
            //    return node.ToJsonString(new JsonSerializerOptions { WriteIndented = true });
            //}

        }

        private void lbshowbird_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (bird Bird in Birds)
            {

                Birds.Add(bird);

            }

            lbshowbird.ItemsSource = Birds;
        }


        private void btncreatebird_Click(object sender, RoutedEventArgs e)
        {

        }



    }



}
