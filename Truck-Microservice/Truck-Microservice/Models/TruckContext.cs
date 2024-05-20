
//This file defines the TruckContext class, which inherits from DbContext.
//It represents the database context for the application and defines DbSet properties for
//interacting with truck-related entities.

using Microsoft.EntityFrameworkCore;
namespace Truck_Microservice.Models
{
    public class TruckContext : DbContext
    {
        public TruckContext(DbContextOptions<TruckContext> options) : base(options)
        {
        }

        public DbSet<Truck> Trucks { get; set; }
        public DbSet<TruckMaster> TruckMasters { get; set; }
        public DbSet<StockItem> StockItems { get; set; }
    }
}
