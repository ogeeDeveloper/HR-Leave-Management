using HrLeaveManagment.BlazerUI.Contracts;
using HrLeaveManagment.BlazerUI.Services.Base;

namespace HrLeaveManagment.BlazerUI.Services
{
    public class LeaveAllocationService : BaseService, ILeaveAllocationeService { 
        public LeaveAllocationService(IClient client) : base(client)
        {
        }
    }
}
