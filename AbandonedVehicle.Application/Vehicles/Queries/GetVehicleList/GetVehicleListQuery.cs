using MediatR;

namespace AbandonedVehicle.Application.Vehicles.Queries.GetVehicleList
{
    public class GetVehicleListQuery : IRequest<VehicleListVm>
    {
        public Guid UserId { get; set; }
    }
}
