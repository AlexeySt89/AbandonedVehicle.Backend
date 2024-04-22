using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbandonedVehicle.Application.Vehicles.Commands.CreateVehicle
{
    public class CreateVehicleCommandValidator : AbstractValidator<CreateVehicleCommand>
    {
        public CreateVehicleCommandValidator()
        {
            RuleFor(createVehicleCommand => createVehicleCommand.Address).NotEmpty().MaximumLength(128);
            RuleFor(createVehicleCommand => createVehicleCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
