using System;
using System.Collections.Generic;

namespace Truck_Microservice.Models
{
    public class StockItem
    {
        public int StockItemId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        // Add other properties as needed
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
