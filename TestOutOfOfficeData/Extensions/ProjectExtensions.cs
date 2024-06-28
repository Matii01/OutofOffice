using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OutOfOfficeData.Lists.Employees;
using OutOfOfficeData.Lists.Leave_Requests;
using OutOfOfficeData.Lists.Projects;
using OutOfOfficeData.Parameters;

namespace OutOfOfficeData.Extensions
{
    public static class ProjectExtensions
    {
        public static IQueryable<Project> Search(this IQueryable<Project> projects,
           ApplicationDbContext context, ProjectParams param)
        {
            if (param.HrManagerId.HasValue)
            {
                var emploee = context.Employees.Where(x => x.PeopleParthner == param.HrManagerId)
                    .Select(x => x.ID)
                    .ToArray();

                projects = context.EmployeeInProject
                    .Where(x => emploee.Contains(x.EmployeeID))
                    .Select(x => x.Project)
                    .Distinct();
            }
            if (param.EmployeeId.HasValue)
            {
                projects = context.EmployeeInProject
                    .Where(x => x.EmployeeID == param.EmployeeId)
                    .Select(x => x.Project);
            }
            if (param.ProjectType?.Length > 0)
            {
                projects = projects.Where(x => param.ProjectType.Contains(x.ProjectType));
            }
            if (param.StartDate.HasValue)
            {
                projects = projects.Where(x => x.StartDate > param.StartDate);
            }
            if (param.EndDate.HasValue)
            {
                projects = projects.Where(x => x.EndDate < param.EndDate);
            }
            if (param.Managers?.Length > 0)
            {
                projects = projects.Where(x => param.Managers.Contains(x.ProjectManager));
            }
            if (param.Statuses?.Length > 0)
            {
                projects = projects.Where(x => param.Statuses.Contains(x.Status));
            }

            return projects;
        }
    }
}
