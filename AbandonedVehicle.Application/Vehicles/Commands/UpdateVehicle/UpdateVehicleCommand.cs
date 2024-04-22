

using MediatR;

namespace AbandonedVehicle.Application.Vehicles.Commands.UpdateVehicle
{
    public class UpdateVehicleCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
    }
}
