using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Truck_Microservice.Models;

namespace Truck_Microservice.Controllers
{
    [RoutePrefix("api/trucks")]
    public class TrucksController : ApiController
    {
        private static List<Truck> trucks = new List<Truck>();
        private static List<TruckMaster> truckMasters = new List<TruckMaster>();
        private static List<StockItem> stockItems = new List<StockItem>();

        // CRUD operations for Trucks
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllTrucks()
        {
            return Ok(trucks);
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetTruckById(int id)
        {
            var truck = trucks.FirstOrDefault(t => t.TruckId == id);
            if (truck == null)
                return NotFound();

            return Ok(truck);
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateTruck(Truck truck)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            truck.TruckId = trucks.Count + 1;
            trucks.Add(truck);
            return Ok(truck);
        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult UpdateTruck(int id, Truck truck)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingTruck = trucks.FirstOrDefault(t => t.TruckId == id);
            if (existingTruck == null)
                return NotFound();

            existingTruck.DriverId = truck.DriverId;
            existingTruck.Description = truck.Description;

            return Ok(existingTruck);
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteTruck(int id)
        {
            var truck = trucks.FirstOrDefault(t => t.TruckId == id);
            if (truck == null)
                return NotFound();

            trucks.Remove(truck);
            return Ok(truck);
        }

        // CRUD operations for Truck Master
        [HttpPost]
        [Route("master/create")]
        public IHttpActionResult CreateTruckMaster(TruckMaster truckMaster)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            truckMasters.Add(truckMaster);
            return Ok(truckMaster);
        }

        [HttpGet]
        [Route("master")]
        public IHttpActionResult GetAllTruckMasters()
        {
            return Ok(truckMasters);
        }

        [HttpGet]
        [Route("master/{id}")]
        public IHttpActionResult GetTruckMasterById(int id)
        {
            var truckMaster = truckMasters.FirstOrDefault(t => t.TruckMasterId == id);
            if (truckMaster == null)
                return NotFound();

            return Ok(truckMaster);
        }

        [HttpPut]
        [Route("master/{id}")]
        public IHttpActionResult UpdateTruckMaster(int id, TruckMaster truckMaster)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingTruckMaster = truckMasters.FirstOrDefault(t => t.TruckMasterId == id);
            if (existingTruckMaster == null)
                return NotFound();

            existingTruckMaster.Description = truckMaster.Description;
            // Update other properties as needed

            return Ok(existingTruckMaster);
        }

        [HttpDelete]
        [Route("master/{id}")]
        public IHttpActionResult DeleteTruckMaster(int id)
        {
            var truckMaster = truckMasters.FirstOrDefault(t => t.TruckMasterId == id);
            if (truckMaster == null)
                return NotFound();

            truckMasters.Remove(truckMaster);
            return Ok(truckMaster);
        }

        // Stock Loading and Offloading functionality
        [HttpPost]
        [Route("stock/loading")]
        public IHttpActionResult LoadStock(StockLoadingRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Validate stock loading request
            // Implement validation logic here

            // Assuming successful validation, proceed with loading
            foreach (var item in request.Items)
            {
                stockItems.Add(item);
            }

            return Ok(request);
        }

        [HttpPost]
        [Route("stock/offloading")]
        public IHttpActionResult UnloadStock(StockOffloadingRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Validate stock offloading request
            // Implement validation logic here

            // Assuming successful validation, proceed with offloading
            foreach (var item in request.Items)
            {
                var existingItem = stockItems.FirstOrDefault(s => s.StockItemId == item.StockItemId);
                if (existingItem != null)
                {
                    existingItem.Quantity -= item.Quantity;
                    // Update other properties as needed
                }
                // Handle case if item not found or quantity exceeds available quantity
            }

            return Ok(request);
        }
    }
}
