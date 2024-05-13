using System;
using System.Collections.Generic;

namespace Truck_Microservice.Models
{
    public class StockItem
    {
        public int StockItemId { get; set; }  // Unique identifier for the stock item
        public string ProductName { get; set; }  // Name of the product
        public int Quantity { get; set; }  // Quantity of the product
        // Other properties as needed
    }

    public class StockLoadingRequest
    {
        public List<StockItem> Items { get; set; }
        // Add other properties as needed
    }

    public class StockOffloadingRequest
    {
        public List<StockItem> Items { get; set; }
        // Add other properties as needed
    }
}
