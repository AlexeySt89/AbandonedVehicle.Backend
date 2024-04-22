using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbandonedVehicle.Domain
{
    public class Vehicle
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
    }
}
