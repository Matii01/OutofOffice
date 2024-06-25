using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using OutOfOfficeData.Lists.Employees;
using OutOfOfficeData.Lists.Projects;
using OutOfOfficeData.Parameters;

namespace OutOfOfficeData.Extensions
{
    public static class EmployeeExtensions
    {
        public static IQueryable<Employee> Search(this IQueryable<Employee> employee, ApplicationDbContext context, EmployeeFilterParams param)
        {
            if (param.ProjectManagerId.HasValue)
            {
                var projectsIds = context.Projects
                    .Where(x => x.ProjectManager == param.ProjectManagerId)
                    .Select(x => x.ID);

                var employeesId = context
                    .EmployeeInProject
                    .Where(x => projectsIds.Contains(x.ProjectID))
                    .Select(x => x.EmployeeID)
                    .Distinct();

                employee = employee
                     .Where(x => x.Position == EmployeePosition.Emplyee)
                     .Where(x => employeesId.Contains(x.ID));
            }
            if (param.FullName != null) 
            {
                employee = employee.Where(x => x.FullName.ToLower().Contains(param.FullName.ToLower()));
            }
            if (param.SubdivisionId?.Length > 0)
            {
                employee = employee.Where(x => param.SubdivisionId.Contains((int)x.Subdivision));
            }
            if (param.PositionId?.Length > 0)
            {
                employee = employee.Where(x => param.PositionId.Contains((int)x.Position));
            }
            if (param.StatusId?.Length > 0)
            {
                employee = employee.Where(x => param.StatusId.Contains((int)x.Status));
            }
            if (param.PeopleParthner?.Length > 0)
            {
                employee = employee.Where(x => param.PeopleParthner.Contains(x.PeopleParthner));
            }
            if (param.OutOfOfficeBalanceMin.HasValue)
            {
                employee = employee.Where(x => x.OutOfOfficeBalance > param.OutOfOfficeBalanceMin);
            }
            if (param.OutOfOfficeBalanceMax.HasValue)
            {
                employee = employee.Where(x => x.OutOfOfficeBalance < param.OutOfOfficeBalanceMax);
            }

            return employee;
        }
    }
}
