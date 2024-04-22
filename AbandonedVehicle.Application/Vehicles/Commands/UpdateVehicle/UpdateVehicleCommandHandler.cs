using MediatR;
using AbandonedVehicle.Domain;
using AbandonedVehicle.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AbandonedVehicle.Application.Common.Exceptions;

namespace AbandonedVehicle.Application.Vehicles.Commands.UpdateVehicle
{
    public class UpdateVehicleCommandHandler : IRequestHandler<UpdateVehicleCommand>
    {
        private IVehicleDbContext _vehicleDbContext;

        public UpdateVehicleCommandHandler(IVehicleDbContext vehicleDbContext)
        {
            _vehicleDbContext = vehicleDbContext;
        }

        public async Task<Unit> Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
        {
            var entity = await _vehicleDbContext.Vehicles.FirstOrDefaultAsync(vehicle => vehicle.Id == request.Id, cancellationToken);

            if(entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Vehicle), request.Id);
            }

            entity.Address = request.Address;
            entity.Description = request.Description;
            entity.EditDate = DateTime.Now;

            await _vehicleDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

    }
}