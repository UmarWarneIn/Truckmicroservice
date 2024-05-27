using System.Collections.Generic;

namespace Truck_Microservice.Models
{
    public class TruckApiResponse
    {
        public List<TruckRecord> TruckRecords { get; set; }

        // Optionally, you can add other properties like status codes, messages, etc.
        // public string Status { get; set; }
        // public string Message { get; set; }
    }
}
