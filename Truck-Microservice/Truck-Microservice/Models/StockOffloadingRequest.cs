using System.Collections.Generic;

namespace Truck_Microservice.Models
{
    public class StockOffloadingRequest
    {
        public int key1 { get; set; }
        public List<StockItem>? Items { get; set; }
    }
}