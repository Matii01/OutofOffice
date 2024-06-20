using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestOutOfOfficeData.Lists.Leave_Requests;

namespace TestOutOfOfficeData.Dto
{
    public record LeaveRequestDto(
        int ID, 
        string EmployeeName, 
        AbsenceReason AbsenceReason, 
        DateTime StartDate, 
        DateTime EndDate, 
        string? Comment, 
        LeaveRequestStatus Status
    );
}
