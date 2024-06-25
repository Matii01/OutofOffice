using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OutOfOfficeData.Dto;
using OutOfOfficeData.Extensions;
using OutOfOfficeData.Lists.Employees;
using OutOfOfficeData.Lists.Projects;
using OutOfOfficeData.Parameters;
using OutOfOfficeData.NewFolder;
using AutoMapper;

namespace OutOfOfficeData.Services
{
    public class ProjectService : BaseService
    {
        public ProjectService(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public async Task<List<ProjectsForListDto>> GetProjectsList(ProjectParams projectParams)
        {
            var list = await _context.Projects
                .Search(_context, projectParams)
                .Select(x => _mapper.Map<ProjectsForListDto>(x))
                .ToListAsync();

            return list;
        }

        public async Task<object> GetProjectsDetails(int id)
        {
            var project = await _context.Projects
                .Where(x => x.ID == id)
                .Select(x => _mapper.Map<ProjectDto>(x))
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

            Project project = _mapper.Map<Project>(newProject, opts => opts.Items["ProjectManager"] = pm);
            
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            return project;
        }

        public async Task<Project> UpdateProject(int id, NewProjectDto newProject)
        {
            var project = await _context.Projects.FindAsync(id) ?? throw new NotFoundException("project not found");
            
            _mapper.Map(newProject, project);

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
                throw new NotFoundException("no employee with the specified id found ");
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
                .SingleOrDefaultAsync() ?? throw new NotFoundException("not found");

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
