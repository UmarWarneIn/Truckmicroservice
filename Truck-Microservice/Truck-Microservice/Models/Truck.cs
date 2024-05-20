//This file defines the Truck model class.
//It represents a truck entity with properties such as TruckId, DriverId, and Description.


using Microsoft.EntityFrameworkCore;

namespace Truck_Microservice.Models
{
    public class Truck
    {
        public int TruckId { get; set; }
        public int DriverId { get; set; }
        public string? Description { get; set; } // Declare as nullable

        // Add other properties if necessary

        public Truck()
        {
            Description = string.Empty; // Initialize in the constructor
        }
    }
}
