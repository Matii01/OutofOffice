using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestOutOfOfficeData.Dto;
using TestOutOfOfficeData.Extensions;
using TestOutOfOfficeData.Lists.Employees;
using TestOutOfOfficeData.Lists.Projects;
using TestOutOfOfficeData.Parameters;

namespace TestOutOfOfficeData.Services
{
    public class ProjectService : BaseService
    {
        public ProjectService(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<List<ProjectsForListDto>> GetProjectsList(ProjectParams projectParams)
        {
            var list = await _context.Projects
                .Search(_context, projectParams)
                .Select(x => new ProjectsForListDto(
                    x.ID,
                    x.ProjectType,
                    x.StartDate,
                    x.EndDate,
                    x.ProjectManager,
                    x.Comment,
                    x.Status
                    ))
                .ToListAsync();

            return list;
        }

        public async Task<object> GetProjectsDetails(int id)
        {
            var project = await _context.Projects
                .Where(x => x.ID == id)
                .Select(x => new ProjectDto(
                        x.ID,
                        x.ProjectType,
                        x.StartDate, x.EndDate,
                        x.ProjectManager,
                        x.Comment,
                        x.Status
                    ))
                .SingleOrDefaultAsync();

            var employee = await _context.EmployeeInProject.Where(x => x.ProjectID == id)
                .Select(x => new
                {
                    Id = x.Employee.ID,
                    fullName = x.Employee.FullName,
                })
                .ToListAsync();


            return new { project, employee };
        }

        public async Task<Project> CreateProject(NewProjectDto newProject, int? projectManagerId)
        {
            int pm = newProject.projectManager;
            if(projectManagerId != null) 
            {
                pm = projectManagerId.Value;
            }

            Project project = new()
            {
                ProjectType = newProject.ProjectType,
                StartDate = newProject.StartDate,
                EndDate = newProject.EndDate,
                ProjectManager = pm,
                Comment = newProject.Comment,
                Status = newProject.Status,
            };

            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            return project;
        }

        public async Task<Project> UpdateProject(int id, NewProjectDto newProject)
        {
            var project = await _context.Projects.FindAsync(id) ?? throw new Exception("not found");

            project.ProjectType = newProject.ProjectType;
            project.StartDate= newProject.StartDate;
            project.EndDate= newProject.EndDate;
            project.ProjectManager = newProject.projectManager;
            project.Comment = newProject.Comment;
            project.Status = newProject.Status;

            await _context.SaveChangesAsync();
            return project;
        }

        public async Task<object> GetProjectParameters()
        {
            var status = Enum.GetValues(typeof(ProjectStatus))
               .Cast<ProjectStatus>()
               .Select(x => new { name = x.ToString(), value = x })
               .ToList();

            var projectType = Enum.GetValues(typeof(ProjectType))
              .Cast<ProjectType>()
              .Select(x => new { name = x.ToString(), value = x })
              .ToList();

            return new
            {
                projectType,
                status,
                pManagers = await GetProjectManagersForSelect()
            };
        }

        public async Task<List<EmployeeForSelect>> GetProjectManagersForSelect()
        {
            var pManagers = await _context.Employees
                .Where(x => x.Position == EmployeePosition.ProjectManager)
                .Select(x => new EmployeeForSelect(x.ID, x.FullName))
                .ToListAsync();

            return pManagers;
        }

        public async Task<EmployeeInProject> AssignEmployeeToProject(NewEmployeInProjectDto employeInProjectDto)
        {
            if(!await CanAssignEmployeeToProject(employeInProjectDto.EmployeeId))
            {
                throw new Exception("not employee");
            }

            EmployeeInProject project = new ()
            {
                EmployeeID = employeInProjectDto.EmployeeId,
                ProjectID = employeInProjectDto.ProjectId,
            };

            _context.EmployeeInProject.Add(project);
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task RemoveEmployeeFromProject(int employeeId, int projectId)
        {
            var employeeproject = await _context.EmployeeInProject
                .Where(x=>x.EmployeeID == employeeId && x.ProjectID == projectId)
                .SingleOrDefaultAsync() ?? throw new Exception("not found");

            _context.EmployeeInProject.Remove(employeeproject);
            await _context.SaveChangesAsync();
        }

        private async Task<bool> CanAssignEmployeeToProject(int employeeId)
        {
            var employee = await _context.Employees
                .Where(x => x.ID == employeeId)
                .Select(x => x.Position)
                .SingleOrDefaultAsync();

            if (employee != EmployeePosition.Emplyee)
            {
                return false;
            }
            return true;
        }
    }
}
