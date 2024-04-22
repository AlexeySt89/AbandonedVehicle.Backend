using AbandonedVehicle.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbandonedVehicle.Persistence.EntityTypeConfigurations
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasKey(v  => v.Id);
            builder.HasIndex(v => v.Id).IsUnique();
            builder.Property(v => v.Address).HasMaxLength(128);
        }
    }
}
