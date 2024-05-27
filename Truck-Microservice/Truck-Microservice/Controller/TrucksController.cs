using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Truck_Microservice.Data;
using Truck_Microservice.Models;

namespace Truck_Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrucksController : ControllerBase
    {
        private readonly TruckContext _context;
        private readonly EpicorIntegrationService _epicorService;

        public TrucksController(TruckContext context, EpicorIntegrationService epicorService)
        {
            _context = context;
            _epicorService = epicorService;
        }

        [HttpGet]
        public IActionResult GetAllTrucks()
        {
            var trucks = _context.Trucks.ToList();
            return Ok(trucks);
        }

        [HttpGet("{id}")]
        public IActionResult GetTruckById(int id)
        {
            var truck = _context.Trucks.FirstOrDefault(t => t.key1 == id);
            if (truck == null)
                return NotFound();

            return Ok(truck);
        }

        [HttpPost]
        public IActionResult CreateTruck([FromBody] Truck truck)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Trucks.Add(truck);
            _context.SaveChanges();

            return Ok(truck);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTruck(int id, [FromBody] Truck truck)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingTruck = _context.Trucks.FirstOrDefault(t => t.key1 == id);
            if (existingTruck == null)
                return NotFound();

            existingTruck.character02 = truck.character02;
            existingTruck.character01 = truck.character01;

            _context.SaveChanges();

            return Ok(existingTruck);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTruck(int id)
        {
            var truck = _context.Trucks.FirstOrDefault(t => t.key1 == id);
            if (truck == null)
                return NotFound();

            _context.Trucks.Remove(truck);
            _context.SaveChanges();

            return Ok(truck);
        }

        [HttpGet("epicor/load/{id}")]
        public async Task<IActionResult> LoadTruckFromEpicor(int id)
        {
            var response = await _epicorService.LoadStockAsync(id);
            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());

            var stock = await response.Content.ReadAsAsync<StockItem>();
            return Ok(stock);
        }

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
