using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestOutOfOfficeData.Lists.Leave_Requests;

namespace TestOutOfOfficeData.Dto
{
    public record NewLeaveRequestDto(
        AbsenceReason AbsenceReason,
        DateTime StartDate,
        DateTime EndDate,
        string? Comment
    );
}
