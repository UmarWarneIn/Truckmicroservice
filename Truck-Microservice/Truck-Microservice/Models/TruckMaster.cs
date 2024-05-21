using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Truck_Microservice.Models
{
    public class TruckMaster
    {
        public TruckMaster()
        {
            Trucks = new List<Truck>();
        }

        [Key]
        public int TruckMasterId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; } = string.Empty;

        public ICollection<Truck> Trucks { get; set; }
    }
}
