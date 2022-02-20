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
    public class PhoneConfiguration : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.Property(p => p.phone).IsRequired().HasMaxLength(30);
            builder.Property(p => p.PhoneType).IsRequired();
            builder.Property(p => p.CountryCode).IsRequired().HasMaxLength(5);
            builder.Property(p => p.AreaCode).IsRequired().HasMaxLength(5);
        }
    }
}
