using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestOutOfOfficeData.Lists.Leave_Requests;

namespace TestOutOfOfficeData.Dto
{
    public record LeaveRequestForApprovalDto(
        int ID,
        string EmployeeName,
        string AbsenceReason,
        DateTime StartDate,
        DateTime EndDate,
        string? Comment,
        string Status
    );
}
