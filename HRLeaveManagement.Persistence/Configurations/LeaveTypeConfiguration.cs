﻿using HRLeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Persistence.Configurations
{
    public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
    {
        public void Configure(EntityTypeBuilder<LeaveType> builder)
        {
            builder.HasData(
                // Seeding the database
                new LeaveType
                {
                    Id = 1,
                    Name = nameof(LeaveType.Name),
                    DefaultDays = 1,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                });
            throw new NotImplementedException();
        }
    }
}
