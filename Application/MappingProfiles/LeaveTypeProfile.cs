using AutoMapper;
using HRLeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.MappingProfiles
{
    public class LeaveTypeProfile : Profile
    {
        public LeaveTypeProfile()
        {
            // Create Maps
            CreateMap<LeaveTypeDto, LeaveType>().ReverseMap();
        }
    }
}
