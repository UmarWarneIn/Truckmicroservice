using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Truck_Microservice.Models
{
    public class ApiDataModel
    {
        // Define properties to match the fields returned by the API
        public int Key1 { get; set; }
        public string Character01 { get; set; }
        public string Character02 { get; set; }
        // Add other properties as needed to match the API response
    }

    public class ApiService
    {
        public async Task<List<ApiDataModel>> FetchApiDataAsync(string apiUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Make a GET request to the API endpoint
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    response.EnsureSuccessStatusCode(); // Throw exception if not successful

                    // Read the response content as a string
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Deserialize the JSON response into a list of ApiDataModel objects
                    List<ApiDataModel> apiDataList = JsonConvert.DeserializeObject<List<ApiDataModel>>(responseBody);

                    return apiDataList;
                }
                catch (HttpRequestException ex)
                {
                    // Log or handle any exceptions
                    // For example:
                    Console.WriteLine($"Error fetching data from API: {ex.Message}");
                    throw;
                }
            }
        }
    }
}
