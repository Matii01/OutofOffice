﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TestOutOfOfficeData;
using TestOutOfOfficeData.Dto;
using TestOutOfOfficeData.Lists.Leave_Requests;
using TestOutOfOfficeData.Parameters;
using TestOutOfOfficeData.Services;

namespace TestForOutofOffice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LeaveRequestController : ControllerBase
    {
        private LeaveRequestService _leacveRequestService;
        private readonly UserManager<ApplicationUser> _userManager;
        public LeaveRequestController(LeaveRequestService leacveRequestService, UserManager<ApplicationUser> userManager)
        {
            _leacveRequestService = leacveRequestService;
            _userManager = userManager;
        }

        [Authorize]
        [HttpGet("leaverequests")]
        public async Task<IActionResult> GetLeaveRequests([FromQuery] LeaveRequestParams requestParams)
        {
            var user = await GetUserByClaims(User);
            var roles = await _userManager.GetRolesAsync(user);

            if (roles.Contains("ProjectManager"))
            {
                requestParams.ProjectManagerId = user.EmployeeId;
            }
            else if (roles.Contains("HRManager"))
            {
                requestParams.HrManagerId = user.EmployeeId;
            }
            else if (roles.Contains("Employee"))
            {
                requestParams.EmployeeId = user.EmployeeId;
            }
            var list = await _leacveRequestService.GetLeaveRequests(requestParams);
            return Ok(list);
        }

        [Authorize]
        [HttpGet("{leaveRequestId}")]
        public async Task<IActionResult> GetLeaveRequests(int leaveRequestId)
        {
            var item = await _leacveRequestService.GetLeaveRequestDetails(leaveRequestId);

            return Ok(item);
        }

        //[Authorize]
        [HttpGet("forleaverequest")]
        public IActionResult GetLeaveRequestParameters()
        {
            var list =  _leacveRequestService.GetLeaveRequestParameters();

            return Ok(list);
        }

        [HttpPost("createleaveRequest")]
        public async Task<IActionResult> CreateLeaveRequest([FromBody] NewLeaveRequestDto newLeaveRequest)
        {
            var user = await GetUserByClaims(User);

            var item = await _leacveRequestService
                .CreateLeaveRequest(user.EmployeeId, newLeaveRequest);
                
            return Ok(item);
        }

        [Authorize(Roles = "Employee")]
        [HttpPost("submitleaveRequest/{leaveRequestId}")]
        public async Task<IActionResult> SubmitLeaveRequest(int leaveRequestId)
        {
            var user = await GetUserByClaims(User);
            await _leacveRequestService.SubmiteLeaveRequest(leaveRequestId, user.EmployeeId);
            return Ok("");
        }

        [HttpPost("cancelleaveRequest/{leaveRequestId}")]
        public async Task<IActionResult> CancelLeaveRequest(int leaveRequestId)
        {
            await _leacveRequestService.CancelLeaveRequest(leaveRequestId);
            return Ok("");
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