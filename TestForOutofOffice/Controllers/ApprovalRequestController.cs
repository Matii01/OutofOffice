using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;
using OutOfOfficeData;
using OutOfOfficeData.Parameters;
using OutOfOfficeData.Services;

namespace OutofOffice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApprovalRequestController : ControllerBase
    {
        private ApprovalRequstService _approvalRequstService;
        private readonly UserManager<ApplicationUser> _userManager;
        public ApprovalRequestController(ApprovalRequstService approvalRequstService, UserManager<ApplicationUser>  userManager)
        {
            _approvalRequstService = approvalRequstService;
            _userManager = userManager;
        }

        [HttpGet("forapprovalrequest")]
        public IActionResult GetLeaveRequestParameters()
        {
            var list = _approvalRequstService.GetAppravalRequestParameters();

            return Ok(list);
        }

        [HttpGet("approvalrequest")]
        public async Task<IActionResult> GetApprovalRequest([FromQuery] ApprovalRequestParams filterParams)
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
            else if (roles.Contains("Employee"))
            {
                filterParams.EmployeeId = user.EmployeeId;
            }

            var list = await _approvalRequstService.GetApprovalRequest(filterParams);

            return Ok(list);
        }

        [HttpGet("approvalrequest/{id}")]
        public async Task<IActionResult> GetApprovalRequestDetails(int id)
        {
            var item = await _approvalRequstService.GetApprovalRequest(id);
            
            return Ok(item);
        }

        [Authorize(Roles = "ProjectManager,HRManager")]
        [HttpPost("accept/{id}")]
        public async Task<IActionResult> AcceptApprovalRequest(int id, [FromBody] string? comment)
        {
            var user = await GetUserByClaims(User);
            await _approvalRequstService.AcceptApprovalRequest(id, user.EmployeeId, comment);

            return Ok("");
        }

        [Authorize(Roles = "ProjectManager,HRManager")]
        [HttpPost("reject/{id}")]
        public async Task<IActionResult> RejectApprovalRequest(int id, [FromBody] string? comment)
        {
            var user = await GetUserByClaims(User);
            await _approvalRequstService.RejecctApprovalRequest(id, user.EmployeeId, comment);

            return Ok();
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
