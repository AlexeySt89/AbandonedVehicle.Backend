using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbandonedVehicle.Application.Vehicles.Commands.UpdateVehicle
{
    public class UpdateVehicleCommandValidator : AbstractValidator<UpdateVehicleCommand>
    {
        public UpdateVehicleCommandValidator()
        {
            RuleFor(updateVehicleCommand => updateVehicleCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(updateVehicleCommand => updateVehicleCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateVehicleCommand => updateVehicleCommand.Address).NotEmpty().MaximumLength(128);
        }
    }
}
