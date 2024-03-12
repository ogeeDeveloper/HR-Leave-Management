using AutoMapper;
using HRLeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveTypeCommand;
using HRLeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveTypeCommand;
using HRLeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypeQuery;
using HRLeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetailQuery;
using HRLeaveManagement.Domain;

namespace HRLeaveManagement.Application.MappingProfiles
{
    public class LeaveTypeProfile : Profile
    {
        public LeaveTypeProfile()
        {
            // Create Maps
            CreateMap<LeaveTypeDto, LeaveType>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeDetailDto>();
            CreateMap<CreateLeaveTypeCommand, LeaveType>();
            CreateMap<UpdateLeaveTypeCommand, LeaveType>();
        }
    }
}
