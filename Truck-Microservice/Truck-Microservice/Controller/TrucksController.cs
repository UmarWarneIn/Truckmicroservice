using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Truck_Microservice.Models;

namespace Truck_Microservice.Controllers
{
    // This controller manages API requests related to trucks
    [Route("api/[controller]")]
    [ApiController]
    public class TrucksController : ControllerBase
    {
        private readonly TruckContext _context;
        private readonly EpicorIntegrationService _epicorService;

        // Constructor to initialize the TruckContext and EpicorIntegrationService
        public TrucksController(TruckContext context, EpicorIntegrationService epicorService)
        {
            _context = context;
            _epicorService = epicorService;
        }

        // GET: api/trucks
        // Fetches all trucks from the database
        [HttpGet]
        public IActionResult GetAllTrucks()
        {
            return Ok(_context.Trucks.ToList());
        }

        // GET: api/trucks/{id}
        // Fetches a specific truck by its ID from the database
        [HttpGet("{id}")]
        public IActionResult GetTruckById(int id)
        {
            var truck = _context.Trucks.FirstOrDefault(t => t.TruckId == id);
            if (truck == null)
                return NotFound();

            return Ok(truck);
        }

        // POST: api/trucks
        // Creates a new truck in the database
        [HttpPost]
        public IActionResult CreateTruck([FromBody] Truck truck)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Trucks.Add(truck);
            _context.SaveChanges();

            return Ok(truck);
        }

        // PUT: api/trucks/{id}
        // Updates an existing truck in the database
        [HttpPut("{id}")]
        public IActionResult UpdateTruck(int id, [FromBody] Truck truck)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingTruck = _context.Trucks.FirstOrDefault(t => t.TruckId == id);
            if (existingTruck == null)
                return NotFound();

            existingTruck.DriverId = truck.DriverId;
            existingTruck.Description = truck.Description;

            _context.SaveChanges();

            return Ok(existingTruck);
        }

        // DELETE: api/trucks/{id}
        // Deletes a truck from the database
        [HttpDelete("{id}")]
        public IActionResult DeleteTruck(int id)
        {
            var truck = _context.Trucks.FirstOrDefault(t => t.TruckId == id);
            if (truck == null)
                return NotFound();

            _context.Trucks.Remove(truck);
            _context.SaveChanges();

            return Ok(truck);
        }

        // GET: api/trucks/epicor/load/{id}
        // Loads stock data from Epicor for a specific truck
        [HttpGet("epicor/load/{id}")]
        public async Task<IActionResult> LoadTruckFromEpicor(int id)
        {
            var response = await _epicorService.LoadStockAsync(id);
            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());

            var stock = await response.Content.ReadAsAsync<StockItem>();
            return Ok(stock);
        }

        // GET: api/trucks/epicor/offload/{id}
        // Offloads stock data from Epicor for a specific truck
        [HttpGet("epicor/offload/{id}")]
        public async Task<IActionResult> OffloadTruckFromEpicor(int id)
        {
            var response = await _epicorService.OffloadStockAsync(id);
            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());

            var stock = await response.Content.ReadAsAsync<StockItem>();
            return Ok(stock);
        }
    }
}
