using System.Collections.Generic;

namespace Truck_Microservice.Models
{
    public class StockLoadingRequest
    {
        public int TruckId { get; set; }
        public List<StockItem> Items { get; set; }
    }
}