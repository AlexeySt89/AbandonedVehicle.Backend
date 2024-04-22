using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbandonedVehicle.Application.Vehicles.Queries.GetVehicleList
{
    public class GetVehicleListQueryValidator : AbstractValidator<GetVehicleListQuery>
    {
        public GetVehicleListQueryValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
        }
    }
}
