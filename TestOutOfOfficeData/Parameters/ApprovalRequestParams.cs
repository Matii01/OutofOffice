using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestOutOfOfficeData.Lists.Approval_Requests;

namespace TestOutOfOfficeData.Parameters
{
    public class ApprovalRequestParams
    {
        public int? ProjectManagerId;
        public int? HrManagerId;
        public int? EmployeeId;
        public ApprovalRequestStatus[]? Statuses { get; set; }
    }
}
