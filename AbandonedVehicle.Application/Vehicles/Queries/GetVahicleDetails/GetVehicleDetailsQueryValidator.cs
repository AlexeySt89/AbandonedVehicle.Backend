using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbandonedVehicle.Application.Vehicles.Queries.GetVahicleDetails
{
    public class GetVehicleDetailsQueryValidator : AbstractValidator<GetVehicleDetailsQuery>
    {
        public GetVehicleDetailsQueryValidator()
        {
            RuleFor(note => note.Id).NotEqual(Guid.Empty);
            RuleFor(note => note.UserId).NotEqual(Guid.Empty);
        }

    }
}
