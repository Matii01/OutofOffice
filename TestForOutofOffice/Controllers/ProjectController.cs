using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using OutOfOfficeData;
using OutOfOfficeData.Dto;
using OutOfOfficeData.Lists.Projects;
using OutOfOfficeData.Parameters;
using OutOfOfficeData.Services;

namespace OutofOffice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly ProjectService _projectService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProjectController(ProjectService projectService, UserManager<ApplicationUser> userManager)
        {
            _projectService = projectService;
            _userManager = userManager;
        }

        [Authorize]
        [HttpGet("projects")]
        public async Task<IActionResult> GetProjects([FromQuery] ProjectParams projestParams)
        {
            var user = await GetUserByClaims(User);
            var roles = await _userManager.GetRolesAsync(user);

            if (roles.Contains("ProjectManager"))
            {
                projestParams.ProjectManagerId = user.EmployeeId;
            }
            else if (roles.Contains("HRManager"))
            {
                projestParams.HrManagerId = user.EmployeeId;
            }
            else if (roles.Contains("Employee"))
            {
                projestParams.EmployeeId = user.EmployeeId;
            }

            var list = await _projectService.GetProjectsList(projestParams);

            return Ok(list);
        }

        [Authorize]
        [HttpGet("fornewproject")]
        public async Task<IActionResult> GetProjectParameters()
        {
            var list = await _projectService.GetProjectParameters();

            return Ok(list);
        }

        //[Authorize]
        [HttpGet("projectDetails/{id}")]
        public async Task<IActionResult> GetProjectDetails(int id)
        {
            var project = await _projectService.GetProjectsDetails(id);
            return Ok(project);
        }

        [Authorize(Roles = "ProjectManager,Administrator")]
        [HttpPost("addproject")]
        public async Task<IActionResult> AddNewProject([FromBody] NewProjectDto newProject)
        {
            var user = await GetUserByClaims(User);
            var roles = await _userManager.GetRolesAsync(user);

            if (roles.Contains("ProjectManager")) 
            {
                await _projectService.CreateProject(newProject, user.EmployeeId);
                //Console.WriteLine("ProjectManager");
            }
            else
            {
                //Console.WriteLine("Admin");
                await _projectService.CreateProject(newProject, null);
            }


            return Ok(newProject);
        }

        [Authorize(Roles = "ProjectManager,Administrator")]
        [HttpPost("updateproject/{id}")]
        public async Task<IActionResult> UpdateProject(int id, [FromBody] NewProjectDto newProject)
        {
            var user = await GetUserByClaims(User);
            var roles = await _userManager.GetRolesAsync(user);

            if (roles.Contains("ProjectManager"))
            {
                // check if pm id is the same 
            }
            
            await _projectService.UpdateProject(id, newProject);

            return Ok(newProject);
        }

        [HttpPost("assignemploye")]
        public async Task<IActionResult> AssignEmployeeToProject([FromBody] NewEmployeInProjectDto employeInProjectDto)
        {
            var item = await _projectService.AssignEmployeeToProject(employeInProjectDto);

            return CreatedAtAction("AssignEmployeeToProject", item);
        }

        [HttpDelete("deletefromproject/{projectId}/{employeeId}")]
        public async Task<IActionResult> RemoveEmployeeFromProject(int projectId, int employeeId)
        {
            await _projectService.RemoveEmployeeFromProject(employeeId, projectId);

            return NoContent();
        }

        private async Task<ApplicationUser> GetUserByClaims(ClaimsPrincipal currentUser)
        {

            var userName = currentUser.FindFirst(ClaimTypes.NameIdentifier)?.Value 
                ?? throw new Exception("Unauthorized");

            var user = await _userManager.FindByNameAsync(userName);

            return user ?? throw new Exception("Unauthorized");
        }
    }
}
