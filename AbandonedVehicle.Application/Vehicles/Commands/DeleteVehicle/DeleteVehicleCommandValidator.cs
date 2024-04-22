using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbandonedVehicle.Application.Vehicles.Commands.DeleteVehicle
{
    public class DeleteVehicleCommandValidator : AbstractValidator<DeleteVehicleCommand>
    {
        public DeleteVehicleCommandValidator()
        {
            RuleFor(deleteVehicleCommand => deleteVehicleCommand.Id).NotEqual(Guid.Empty);
            RuleFor(deleteVehicleCommand => deleteVehicleCommand.UserId).NotEqual(Guid.Empty);

        }
    }
}
