using AbandonedVehicle.Domain;
using MediatR;

namespace AbandonedVehicle.Application.Vehicles.Queries.GetVahicleDetails
{
    public class GetVehicleDetailsQuery : IRequest<VehicleDetailsVm>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
