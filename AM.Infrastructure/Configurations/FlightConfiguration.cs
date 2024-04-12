using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configurations
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.HasKey(f => f.FlightId);
            //builder.HasMany(f => f.Passengers).WithMany(p => p.Flights).UsingEntity(j => j.ToTable("Reservation"));
            builder.HasOne(f => f.FlightPlane).WithMany(p => p.Flights).HasForeignKey(f => f.PlaneId).OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
