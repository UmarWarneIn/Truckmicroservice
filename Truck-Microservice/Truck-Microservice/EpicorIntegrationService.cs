using System.Net.Http;
using System.Threading.Tasks;
using Truck_Microservice.Models;

public class EpicorIntegrationService
{
    private readonly HttpClient _httpClient;

    public EpicorIntegrationService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<HttpResponseMessage> LoadStockAsync(Stock stock)
    {
        // Make HTTP request to Epicor API to load stock
        var response = await _httpClient.PostAsJsonAsync("https://77.92.189.102/IITPrecastVertical/Apps/RestHelp/stock/load", stock);
        return response;
    }
}
