using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OutOfOfficeData.Lists.Approval_Requests;
using OutOfOfficeData.Lists.Leave_Requests;

namespace OutOfOfficeData.Parameters
{
    public class LeaveRequestParams
    {
        public int? HrManagerId;
        public int? ProjectManagerId;
        public int? EmployeeId;
        public DateTime? StartDate;
        public DateTime? EndDate;
        public AbsenceReason[]? AbsenceReasons { get; set; }
        public LeaveRequestStatus[]? Statuses { get; set; }
    }
}
