﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TestOutOfOfficeData;
using TestOutOfOfficeData.Dto;
using TestOutOfOfficeData.Lists.Employees;
using TestOutOfOfficeData.Parameters;
using TestOutOfOfficeData.Services;

namespace TestForOutofOffice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private EmployeeService _employeeService;
        private readonly UserManager<ApplicationUser> _userManager;
        public EmployeeController(EmployeeService employeeService, UserManager<ApplicationUser> userManager)
        {
            _employeeService = employeeService;
            _userManager = userManager;
        }

        [Authorize(Roles = "HRManager,ProjectManager,Administrator")]
        [HttpGet("employee")]
        public async Task<IActionResult> GetEmployee([FromQuery] EmployeeFilterParams filterParams)
        {
            var user = await GetUserByClaims(User);
            var roles = await _userManager.GetRolesAsync(user);

            if (roles.Contains("ProjectManager"))
            {
                filterParams.ProjectManagerId = user.EmployeeId;
            }
            else if (roles.Contains("HRManager"))
            {
                filterParams.HrManagerId = user.EmployeeId;
            }

            var list = await _employeeService.GetEmployeeList(filterParams);
            return Ok(list);
        }

        [HttpGet("employeeposition")]
        public async Task<IActionResult> GetEmployeeForPositionEmployee()
        {
            EmployeeFilterParams filterParams = new ()
            {
                PositionId = [(int)EmployeePosition.Emplyee]
            };
            var list = await _employeeService.GetEmployeeList(filterParams);

            return Ok(list.Select(x => new
            {
                Id = x.ID,
                fullName = x.FullName,
            }).ToList());
        }

        [HttpGet("notinprojectemployee/{projectId}")]
        public async Task<IActionResult> GetNotInThisProjectEmployee(int projectId)
        {
            var list = await _employeeService.GetNotInThisProjectEmployee(projectId);
            
            return Ok(list);
        }

        [HttpGet("fornewemployee")]
        public async Task<IActionResult> GetParametersForNewEmployee()
        {
            var list = await _employeeService.GetParametersForNewEmployee();

            return Ok(list);
        }

        [Authorize(Roles = "HRManager,Administrator")]
        [HttpPost("addemployee")]
        public async Task<IActionResult> AddNewEmployee([FromBody] NewEmployeeDto employee)
        {
            var user = await GetUserByClaims(User);
            var roles = await _userManager.GetRolesAsync(user);

            if (roles.Contains("HRManager"))
            {
                await _employeeService.AddNewEmployee(employee, user.EmployeeId);
                return Ok(employee);
            }
            await _employeeService.AddNewEmployee(employee);
            return Ok(employee);
        }

        [HttpPost("updateemployee")]
        public async Task<IActionResult> UpdataeEmployee([FromBody] EditEmployeeDto employee)
        {
            await _employeeService.EditEmployee(employee);
            return Ok(employee);
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