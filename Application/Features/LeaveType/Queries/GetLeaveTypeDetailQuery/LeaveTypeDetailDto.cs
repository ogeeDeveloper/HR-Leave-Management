using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetailQuery
{
    public class LeaveTypeDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int DefaultDays { get; set; }
        public int? Created { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? Modified { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
