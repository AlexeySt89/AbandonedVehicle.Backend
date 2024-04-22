using AbandonedVehicle.Application.Interfaces;
using AbandonedVehicle.Domain;
using AbandonedVehicle.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace AbandonedVehicle.Persistence
{
    public class VehicleDbContext : DbContext, IVehicleDbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }

        public VehicleDbContext(DbContextOptions<VehicleDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VehicleConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}