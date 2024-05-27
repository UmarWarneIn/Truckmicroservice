using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Truck_Microservice.Services
{
    public class EpicorApiService
    {
        private readonly HttpClient _httpClient;

        public EpicorApiService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<string> GetTruckDataAsync(string apiUrl)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

                if (!response.IsSuccessStatusCode)
                {
                    // Handle non-success status code
                    return null;
                }

                string responseData = await response.Content.ReadAsStringAsync();
                return responseData;
            }
            catch (Exception ex)
            {
                // Handle exception
                return null;
            }
        }
    }
}
