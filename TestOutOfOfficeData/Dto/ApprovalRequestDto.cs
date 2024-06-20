using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OutOfOfficeData.Lists.Approval_Requests;
using OutOfOfficeData.Lists.Leave_Requests;

namespace OutOfOfficeData.Dto
{
    public record ApprovalRequestDto(
       int ID,
       string? Approver,
       LeaveRequestForApprovalDto LeaveRequest,
       ApprovalRequestStatus Status,
       string? Comment
    );

}
