﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data.Configuration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(45);
            builder.Property(p => p.MiddleName).IsRequired().HasMaxLength(45);
            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(45);
            builder.Property(p => p.Gender).IsRequired();
        }
    }
}
