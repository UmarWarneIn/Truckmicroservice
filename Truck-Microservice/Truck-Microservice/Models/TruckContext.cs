using Microsoft.EntityFrameworkCore;
using Truck_Microservice.Models;

namespace Truck_Microservice.Data
{
    public class TruckContext : DbContext
    {
        public TruckContext(DbContextOptions<TruckContext> options) : base(options)
        {
        }

        public DbSet<TruckRecord> TruckRecords { get; set; }
        public DbSet<Truck> Trucks { get; set; }
        public DbSet<StockItem> StockItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize entity configurations if necessary
        }
    }
}
