using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestOutOfOfficeData.Lists.Approval_Requests;
using TestOutOfOfficeData.Lists.Leave_Requests;

namespace TestOutOfOfficeData.Dto
{
    public record ApprovalRequestDto(
       int ID,
       string? Approver,
       LeaveRequestForApprovalDto LeaveRequest,
       ApprovalRequestStatus Status,
       string? Comment
    );

}
