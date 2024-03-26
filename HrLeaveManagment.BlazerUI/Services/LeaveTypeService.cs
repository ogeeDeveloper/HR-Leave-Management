using AutoMapper;
using HrLeaveManagment.BlazerUI.Contracts;
using HrLeaveManagment.BlazerUI.Models;
using HrLeaveManagment.BlazerUI.Services.Base;

namespace HrLeaveManagment.BlazerUI.Services
{
    public class LeaveTypeService : BaseService, ILeaveTypeService
    {
        private readonly IMapper _mapper;
        public LeaveTypeService(IClient client, IMapper mapper) : base(client)
        {
            _mapper = mapper;
        }

        public async Task<Response<Guid>> CreateLeaveType(LeaveTypeVM leaveType)
        {
            try
            {
                // Map from LeaveTypeVm to CreateLeaveTypeCommand
                var createLeaveTypeCommand = _mapper.Map<CreateLeaveTypeCommand>(leaveType);

                await _client.LeaveTypePOSTAsync(createLeaveTypeCommand);

                return new Response<Guid>()
                {
                    Success = true,
                };
            }
            catch (ApiException ex) {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<Response<Guid>> DeleteLeaveType(int id)
        {
            try
            {
                await _client.LeaveTypeDELETEAsync(id);
                return new Response<Guid>()
                {
                    Success = true
                };
            }catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<LeaveTypeVM> GetLeaveDetails(int id)
        {
            var leaveType = await _client.LeaveTypeGETAsync(id);
            return _mapper.Map<LeaveTypeVM>(leaveType);
        }

        public async Task<List<LeaveTypeVM>> GetLeaveTypes()
        {
            var leaveTypes = await _client.LeaveTypeAllAsync();
            return _mapper.Map<List<LeaveTypeVM>>(leaveTypes);
        }

        public async Task<Response<Guid>> UpdateLeaveType(int id, LeaveTypeVM leaveType)
        {
            try
            {
                var updateLeaveType = _mapper.Map<UpdateLeaveTypeCommand>(leaveType);
                await _client.LeaveTypePUTAsync(id.ToString(), updateLeaveType);
                return new Response<Guid>() { Success = true };
            }catch(ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }
    }
}
