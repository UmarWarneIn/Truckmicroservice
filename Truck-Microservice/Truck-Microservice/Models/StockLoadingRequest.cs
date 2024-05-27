using System.Collections.Generic;

namespace Truck_Microservice.Models
{
    public class StockLoadingRequest
    {
        public int key1  { get; set; }
        public List<StockItem>? Items { get; set; }
    }
}