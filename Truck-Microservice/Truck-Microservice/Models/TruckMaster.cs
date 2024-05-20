//This file defines the TruckMaster model class.
//It represents a master record for trucks with properties such as TruckMasterId and Description.

using System.ComponentModel.DataAnnotations;

namespace Truck_Microservice.Models
{
    public class TruckMaster
    {
        public int TruckMasterId { get; set; }
        public string Description { get; set; }
        // Add other properties if necessary
    }
}
