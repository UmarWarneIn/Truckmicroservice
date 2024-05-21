//This file defines the StockItem model class.
//It represents an item in the stock with properties such as StockItemId, Quantity, and Description.
using System.ComponentModel.DataAnnotations;

namespace Truck_Microservice.Models
{
    public class StockItem
    {
        [Key]
        public int StockItemId { get; set; }

        [Required]
        public int TruckId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
