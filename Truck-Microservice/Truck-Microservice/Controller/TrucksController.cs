using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

using Truck_Microservice.Models;

public class TrucksController : ApiController
{
    private readonly HttpClient _httpClient;

    public TrucksController()
    {
        _httpClient = new HttpClient();
    }

    // GET: api/trucks
    public IHttpActionResult Get()
    {
        // Retrieve trucks from database or other source
        var trucks = new List<Truck> { /* Populate trucks */ };
        return Ok(trucks);
    }

    // POST: api/trucks
    public IHttpActionResult Post(Truck truck)
    {
        // Validate truck data
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        // Save truck to database or other source
        // Return success response
        return Ok();
    }

    // Implement other CRUD operations as needed

    // Integrate with Epicor API
    private async Task<HttpResponseMessage> LoadStockAsync(Stock stock)
    {
        // Make HTTP request to Epicor API to load stock
        var response = await _httpClient.PostAsJsonAsync("https://77.92.189.102/IITPrecastVertical/Apps/RestHelp/stock/load", stock);
        return response;
    }
}
