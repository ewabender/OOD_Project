using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Project
{
    public class EbirdClient
    {

        private readonly HttpClient _httpClient;
        List<JsonBird> allBirds = new List<JsonBird>();

        public EbirdClient(string apiKey)
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


        async Task GetBirdsFromAPI() // initiates api
        {
            string apiKey = "31ichicpcbi7";

            var client = new EbirdClient(apiKey);
            string json = await client.GetRecentObservations("IE"); // IE = Ireland



            allBirds = JsonConvert.DeserializeObject<List<JsonBird>>(json);
            //static string PrettyPrintJson(string json)
            //{
            //    var node = JsonNode.Parse(json);
            //    return node.ToJsonString(new JsonSerializerOptions { WriteIndented = true });
            //}

        }
    }
}
