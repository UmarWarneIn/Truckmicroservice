using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Truck_Microservice.Models;

namespace Truck_Microservice.Controllers
{
    public class StockController : ApiController
    {
        private readonly HttpClient _httpClient;

        public StockController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpPost]
        public async Task<IHttpActionResult> LoadStock(StockLoadingRequest stockRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Logic to validate stock data before loading

            // Make HTTP request to Epicor API to load stock
            var response = await _httpClient.PostAsJsonAsync("https://77.92.189.102/IITPrecastVertical/Apps/RestHelp/stock/load", stockRequest);
            if (!response.IsSuccessStatusCode)
                return InternalServerError();

            return Ok();
        }

        [HttpPost]
        public async Task<IHttpActionResult> OffloadStock(StockOffloadingRequest stockRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Logic to validate stock data before offloading

            // Make HTTP request to Epicor API to offload stock
            var response = await _httpClient.PostAsJsonAsync("https://77.92.189.102/IITPrecastVertical/Apps/RestHelp/stock/offload", stockRequest);
            if (!response.IsSuccessStatusCode)
                return InternalServerError();

            return Ok();
        }
    }
}
