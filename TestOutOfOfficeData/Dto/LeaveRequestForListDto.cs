using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OutOfOfficeData.Lists.Leave_Requests;

namespace OutOfOfficeData.Dto
{
    public record LeaveRequestForListDto(
       int ID,
       string EmployeeName,
       string AbsenceReason,
       DateTime StartDate,
       DateTime EndDate,
       string? Comment,
       string Status
    );
}
