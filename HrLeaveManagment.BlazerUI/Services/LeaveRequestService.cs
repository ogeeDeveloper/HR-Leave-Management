using HrLeaveManagment.BlazerUI.Contracts;
using HrLeaveManagment.BlazerUI.Services.Base;

namespace HrLeaveManagment.BlazerUI.Services
{
    public class LeaveRequestService : BaseService, ILeaveRequestService
    {
        public LeaveRequestService(IClient client) : base(client)
        {
        }
    }
}
