using System.ComponentModel.DataAnnotations;

namespace Truck_Microservice.Models
{
    public class TruckRecord
    {
        [Required]
        public string Key1 { get; set; }

        [StringLength(50)]
        public string Character01 { get; set; }

        [StringLength(50)]
        public string Character02 { get; set; }

        [StringLength(50)]
        public string Character03 { get; set; }

        // Add other validation attributes as needed
    }
}
