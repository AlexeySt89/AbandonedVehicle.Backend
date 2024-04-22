using AbandonedVehicle.Application.Common.Exceptions;
using AbandonedVehicle.Application.Interfaces;
using AbandonedVehicle.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AbandonedVehicle.Application.Vehicles.Commands.DeleteVehicle
{
    public class DeleteVehicleCommandHandler : IRequestHandler<DeleteVehicleCommand>
    {
        private readonly IVehicleDbContext _vehicleDbContext;

        public DeleteVehicleCommandHandler(IVehicleDbContext vehicleDbContext)
        {
            _vehicleDbContext = vehicleDbContext;
        }

        public async Task<Unit> Handle(DeleteVehicleCommand request, CancellationToken cancellationToken)
        {
            var entity = await _vehicleDbContext.Vehicles.FindAsync(new object[] { request.Id }, cancellationToken);

            if(entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Vehicle), request.Id);
            }

            _vehicleDbContext.Vehicles.Remove(entity);
            await _vehicleDbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}