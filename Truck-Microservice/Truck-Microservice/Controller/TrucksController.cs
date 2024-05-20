// This file contains the TrucksController class, which is an API controller for handling CRUD
// operations related to trucks.
//It defines HTTP endpoints for retrieving, creating, updating, and deleting trucks.
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IActionResult GetAllTrucks()
        {
            return Ok(_context.Trucks.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetTruckById(int id)
        {
            var truck = _context.Trucks.FirstOrDefault(t => t.TruckId == id);
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

            var existingTruck = _context.Trucks.FirstOrDefault(t => t.TruckId == id);
            if (existingTruck == null)
                return NotFound();

            existingTruck.DriverId = truck.DriverId;
            existingTruck.Description = truck.Description;

            _context.SaveChanges();

            return Ok(existingTruck);
        }

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
    }
}
