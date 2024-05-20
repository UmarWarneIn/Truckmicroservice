//This file defines the TruckMaster model class.
//It represents a master record for trucks with properties such as TruckMasterId and Description.
using System.Collections.Generic;

namespace Truck_Microservice.Models
{
    public class TruckMaster
    {
        public ICollection<Truck>? Trucks { get; set; }

        public int TruckMasterId { get; set; }
        public string? Description { get; set; }

        // Add other properties if necessary

        public TruckMaster()
        {
            Trucks = new List<Truck>();
        }
    }
}
