using AutoMapper;
using HrLeaveManagment.BlazerUI.Models;
using HrLeaveManagment.BlazerUI.Services.Base;

namespace HrLeaveManagment.BlazerUI.MappingProfiles
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<LeaveTypeDto, LeaveTypeVM>().ReverseMap();
            CreateMap<CreateLeaveTypeCommand, LeaveTypeVM>().ReverseMap();
            CreateMap<UpdateLeaveTypeCommand, LeaveTypeVM>().ReverseMap();
        }
    }
}
