using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbandonedVehicle.Application.Vehicles.Commands.CreateVehicle
{
    public class CreateVehicleCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
    }
}
