using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using OutOfOfficeData;
using OutOfOfficeData.Dto;
using OutOfOfficeData.Lists.Leave_Requests;
using OutOfOfficeData.Parameters;
using OutOfOfficeData.Services;

namespace OutofOffice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LeaveRequestController : BaseController
    {
        private LeaveRequestService _leacveRequestService;
        public LeaveRequestController(LeaveRequestService leacveRequestService, UserManager<ApplicationUser> userManager)
            : base(userManager)
        {
            _leacveRequestService = leacveRequestService;
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
    }
}
