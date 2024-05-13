using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Truck_Microservice.Models;

namespace Truck_Microservice.Controllers
{
    public class StockController : ApiController
    {
        private readonly HttpClient _httpClient;

        // Constructor to initialize HttpClient
        public StockController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Endpoint for loading stock
        [HttpPost]
        public async Task<IHttpActionResult> LoadStock(StockLoadingRequest stockRequest)
        {
            // Check if the received data is valid
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // Return bad request if data is not valid

            // Logic to validate stock data before loading
            // You can implement custom validation logic here

            // Make HTTP request to Epicor API to load stock
            var response = await _httpClient.PostAsJsonAsync("https://77.92.189.102/IITPrecastVertical/Apps/RestHelp/stock/load", stockRequest);
            if (!response.IsSuccessStatusCode) // Check if the request was successful
                return InternalServerError(); // Return internal server error if request was not successful

            return Ok(); // Return OK response if stock loading was successful
        }

        // Endpoint for offloading stock
        [HttpPost]
        public async Task<IHttpActionResult> OffloadStock(StockOffloadingRequest stockRequest)
        {
            // Check if the received data is valid
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // Return bad request if data is not valid

            // Logic to validate stock data before offloading
            // You can implement custom validation logic here

            // Make HTTP request to Epicor API to offload stock
            var response = await _httpClient.PostAsJsonAsync("https://77.92.189.102/IITPrecastVertical/Apps/RestHelp/stock/offload", stockRequest);
            if (!response.IsSuccessStatusCode) // Check if the request was successful
                return InternalServerError(); // Return internal server error if request was not successful

            return Ok(); // Return OK response if stock offloading was successful
        }
    }
}
