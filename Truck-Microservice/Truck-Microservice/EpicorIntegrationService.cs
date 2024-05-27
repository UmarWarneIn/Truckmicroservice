using System.Net.Http;
using System.Threading.Tasks;
using Truck_Microservice.Models;

public class EpicorIntegrationService
{
    private readonly HttpClient _httpClient;

    // Constructor to initialize the HttpClient
    public EpicorIntegrationService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Sends a GET request to Epicor API to load stock data for a specific truck
    public async Task<HttpResponseMessage> LoadStockAsync(int Key1)
    {
        var response = await _httpClient.GetAsync($"https://77.92.189.102/IITPrecastVertical/Apps/RestHelp/stock/load/{Key1}");
        return response;
    }

    // Sends a GET request to Epicor API to offload stock data for a specific truck
    public async Task<HttpResponseMessage> OffloadStockAsync(int key1)
    {
        var response = await _httpClient.GetAsync($"https://77.92.189.102/IITPrecastVertical/Apps/RestHelp/stock/offload/{key1}");
        return response;
    }
}
