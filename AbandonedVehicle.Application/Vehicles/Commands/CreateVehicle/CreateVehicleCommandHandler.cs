using AbandonedVehicle.Application.Interfaces;
using AbandonedVehicle.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbandonedVehicle.Application.Vehicles.Commands.CreateVehicle
{
    public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand, Guid>
    {
        private IVehicleDbContext _vehicleDbContext;

        public CreateVehicleCommandHandler(IVehicleDbContext vehicleDbContext)
        {
            _vehicleDbContext = vehicleDbContext;
        }

        public async Task<Guid> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
        {
            var vehicle = new Vehicle
            {
                UserId = request.UserId,
                Address = request.Address,
                Description = request.Description,
                Id = new Guid(),
                CreationDate = DateTime.Now,
                EditDate = null
            };

            await _vehicleDbContext.Vehicles.AddAsync(vehicle, cancellationToken);
            await _vehicleDbContext.SaveChangesAsync(cancellationToken);

            return vehicle.Id;
        }
    }
}
