using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestOutOfOfficeData.Lists.Approval_Requests;
using TestOutOfOfficeData.Lists.Employees;
using TestOutOfOfficeData.Lists.Leave_Requests;
using TestOutOfOfficeData.Parameters;

namespace TestOutOfOfficeData.Extensions
{
    public static class LeaveRequestExtensions
    {
        public static IQueryable<LeaveRequest> Search(this IQueryable<LeaveRequest> leaveRequest, 
            ApplicationDbContext context, LeaveRequestParams param)
        {
            if (param.HrManagerId.HasValue)
            {
                var employeeIds = context.Employees
                    .Where(x => x.Position == EmployeePosition.Emplyee)
                    .Where(x => x.PeopleParthner == param.HrManagerId)
                    .Select(x => x.ID)
                    .ToArray();

                leaveRequest = leaveRequest.Where(x => employeeIds.Contains(x.EmployeeId));
            }

            if (param.ProjectManagerId.HasValue)
            {
                var projectsIds = context.Projects
                    .Where(x => x.ProjectManager == param.ProjectManagerId)
                    .Select(x => x.ID)
                    .ToArray();

                var employeeIds = context.EmployeeInProject
                    .Where(x => projectsIds.Contains(x.ProjectID))
                    .Select(x => x.EmployeeID)
                    .ToArray();

                leaveRequest = leaveRequest
                    .Where(x => employeeIds.Contains(x.EmployeeId));

            }

            if (param.EmployeeId.HasValue)
            {
                 leaveRequest = leaveRequest
                   .Where(x => x.EmployeeId == param.EmployeeId);
            }

            if (param.StartDate.HasValue)
            {
                leaveRequest = leaveRequest.Where(x => x.StartDate > param.StartDate);
            }

            if (param.EndDate.HasValue)
            {
                leaveRequest = leaveRequest.Where(x => x.EndDate < param.EndDate);
            }

            if (param.AbsenceReasons?.Length > 0)
            {
                leaveRequest = leaveRequest
                                  .Where(x => param.AbsenceReasons.Contains(x.AbsenceReason));
            }

            if (param.Statuses?.Length > 0)
            {
                leaveRequest = leaveRequest
                                  .Where(x => param.Statuses.Contains(x.Status));
            }

            return leaveRequest;
        }
    }
}
