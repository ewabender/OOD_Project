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
    }
}
