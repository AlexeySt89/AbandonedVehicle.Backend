using AbandonedVehicle.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AbandonedVehicle.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<VehicleDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IVehicleDbContext, VehicleDbContext>();
            return services;
        }
    }
}
