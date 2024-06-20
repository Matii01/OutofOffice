using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OutOfOfficeData.Lists.Approval_Requests;
using OutOfOfficeData.Lists.Employees;
using OutOfOfficeData.Lists.Leave_Requests;
using OutOfOfficeData.Parameters;

namespace OutOfOfficeData.Extensions
{
    public static class ApprovalRequestExtensions
    {
        public static IQueryable<ApprovalRequest> Search(this IQueryable<ApprovalRequest> approvalRequest,
            ApplicationDbContext context, ApprovalRequestParams param)
        {
            if (param.HrManagerId.HasValue)
            {
                var employeeIds = context.Employees
                    .Where(x => x.Position == EmployeePosition.Emplyee)
                    .Where(x => x.PeopleParthner == param.HrManagerId)
                    .Select(x => x.ID)
                    .ToArray();

                var leaveRequests = context.LeaveRequests
                    .Where(x => employeeIds.Contains(x.EmployeeId))
                    .Select(x => x.ID)
                    .ToArray();

                approvalRequest = approvalRequest.Where(x => leaveRequests.Contains(x.LeaverRequest));
            }

            if (param.ProjectManagerId.HasValue)
            {
                var projectsIds = context.Projects
                    .Where(x => x.ProjectManager == param.ProjectManagerId)
                    .Select (x => x.ID)
                    .ToArray();

                var employeeIds = context.EmployeeInProject
                    .Where(x => projectsIds.Contains(x.ProjectID))
                    .Select(x => x.EmployeeID)
                    .ToArray();

                var leaveRequests = context.LeaveRequests
                    .Where(x => employeeIds.Contains(x.EmployeeId))
                    .Select(x => x.ID)
                    .ToArray();

                approvalRequest = approvalRequest.Where(x => leaveRequests.Contains(x.LeaverRequest));
            }

            if (param.EmployeeId.HasValue)
            {
                var leaveRequests = context.LeaveRequests
                   .Where(x => x.EmployeeId == param.EmployeeId)
                   .Select(x => x.ID)
                   .ToArray();

                approvalRequest = approvalRequest.Where(x => leaveRequests.Contains(x.LeaverRequest));
            }

            if (param.Statuses?.Length > 0)
            {
                approvalRequest = approvalRequest
                                 .Where(x => param.Statuses.Contains(x.Status));
            }

            return approvalRequest;
        }
    }
}
