using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data.Configuration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(p => p.AddressLine).IsRequired().HasMaxLength(100);
            builder.Property(p => p.City).IsRequired().HasMaxLength(45);
            builder.Property(p => p.ZipPostCode).IsRequired().HasMaxLength(45);
            builder.Property(p => p.State).IsRequired().HasMaxLength(45);
        }
    }
}
