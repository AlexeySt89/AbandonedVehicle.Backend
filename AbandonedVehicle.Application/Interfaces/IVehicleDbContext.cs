using AbandonedVehicle.Domain;
using Microsoft.EntityFrameworkCore;

namespace AbandonedVehicle.Application.Interfaces
{
    public interface IVehicleDbContext
    {
        DbSet<Vehicle> Vehicles { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
