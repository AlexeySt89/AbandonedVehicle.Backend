namespace AbandonedVehicle.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(VehicleDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
