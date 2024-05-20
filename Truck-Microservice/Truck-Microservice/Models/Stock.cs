//This file defines the StockItem model class.
//It represents an item in the stock with properties such as StockItemId, Quantity, and Description.
namespace Truck_Microservice.Models
{
    public class StockItem
    {
        public int StockItemId { get; set; }
        public int TruckId { get; set; }
        public int Quantity { get; set; }
        // Add other properties if necessary
    }
}