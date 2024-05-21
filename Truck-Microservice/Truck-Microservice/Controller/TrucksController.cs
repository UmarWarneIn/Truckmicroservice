using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Truck_Microservice.Models;

namespace Truck_Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrucksController : ControllerBase
    {
        private readonly TruckContext _context;

        public TrucksController(TruckContext context)
        {
            _context = context;
        }

        
        /// Get all trucks
        /// <returns>List of trucks</returns>
        [HttpGet]
        [Route("api/trucks/getalltrucks")]
        public IActionResult GetAllTrucks()
        {
            return Ok(_context.Trucks.ToList());
        }

        /// Get a truck by ID
        /// <param name="id">Truck ID</param>
        /// <returns>Truck object</returns>
        [HttpGet("{id}")]
        [Route("api/trucks/gettruckbyid/{id}")]
        public IActionResult GetTruckById(int id)
        {
            var truck = _context.Trucks.FirstOrDefault(t => t.TruckId == id);
            if (truck == null)
                return NotFound();

            return Ok(truck);
        }

       
        /// Create a new truck
        /// <param name="truck">Truck object</param>
        /// <returns>Created truck</returns>
        [HttpPost]
        [Route("api/trucks/createtruck")]
        public IActionResult CreateTruck([FromBody] Truck truck)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Trucks.Add(truck);
            _context.SaveChanges();

            return Ok(truck);
        }

        /// Update an existing truck
        /// <param name="id">Truck ID</param>
        /// <param name="truck">Updated truck object</param>
        /// <returns>Updated truck</returns>
        [HttpPut("{id}")]
        [Route("api/trucks/updatetruck/{id}")]
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

    
        /// Delete a truck by ID
        /// <param name="id">Truck ID</param>
        /// <returns>Deleted truck</returns>
        [HttpDelete("{id}")]
        [Route("api/trucks/deletetruck/{id}")]
        public IActionResult DeleteTruck(int id)
        {
            var truck = _context.Trucks.FirstOrDefault(t => t.TruckId == id);
            if (truck == null)
                return NotFound();

            _context.Trucks.Remove(truck);
            _context.SaveChanges();

            return Ok(truck);
        }
    }
}
