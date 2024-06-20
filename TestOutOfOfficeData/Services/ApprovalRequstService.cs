using Microsoft.EntityFrameworkCore;
using TestOutOfOfficeData.Dto;
using TestOutOfOfficeData.Extensions;
using TestOutOfOfficeData.Lists.Approval_Requests;
using TestOutOfOfficeData.Lists.Leave_Requests;
using TestOutOfOfficeData.Parameters;

namespace TestOutOfOfficeData.Services
{
    public class ApprovalRequstService : BaseService
    {
        public ApprovalRequstService(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<ApprovalRequstForListDto>> GetApprovalRequest(ApprovalRequestParams requestParams)
        {
            var approvalList = await _context.ApprovalRequests
                .Search(_context, requestParams)
                .Select(item => new ApprovalRequstForListDto(
                    item.ID,
                    item.LeaveRequestProp.Employee.FullName,
                    item.Approver == 0 ? "" : _context.Employees
                        .Where(e => e.ID == item.Approver)
                        .Select(e => e.FullName)
                        .SingleOrDefault() ?? "",
                    item.Status.ToString()
                ))
                .ToListAsync();

            return approvalList;
        }


        public async Task<ApprovalRequestDto> GetApprovalRequest(int approvalRequestId)
        {
            var approvalRequest = await _context.ApprovalRequests
                .Where(ar => ar.ID == approvalRequestId)
                .Select(ar => new ApprovalRequestDto(
                    ar.ID,
                    ar.Approver == 0 ? "" : _context.Employees
                        .Where(e => e.ID == ar.Approver)
                        .Select(e => e.FullName)
                        .SingleOrDefault() ?? "",
                    new LeaveRequestForApprovalDto(
                        ar.LeaveRequestProp.ID,
                        ar.LeaveRequestProp.Employee.FullName,
                        ar.LeaveRequestProp.AbsenceReason.ToString(),
                        ar.LeaveRequestProp.StartDate,
                        ar.LeaveRequestProp.EndDate,
                        ar.LeaveRequestProp.Comment,
                        ar.LeaveRequestProp.Status.ToString()
                    ),
                    ar.Status,
                    ar.Comment
                ))
                .SingleOrDefaultAsync() ?? throw new Exception("not found");

            return approvalRequest;
        }

        public async Task AcceptApprovalRequest(int approvalRequestId, int approver, string? comment)
        {
            var item = await _context.ApprovalRequests
                .Include(x => x.LeaveRequestProp)
                .ThenInclude(x => x.Employee)
                 .Where(x => x.ID == approvalRequestId)
                 .SingleOrDefaultAsync() ?? throw new Exception("not found");

            if(item.Status != ApprovalRequestStatus.New)
            {
                throw new Exception("status error");
            }

            var start = item.LeaveRequestProp.StartDate;
            var end = item.LeaveRequestProp.EndDate;
            var result = (end - start).Days;

            if(result > item.LeaveRequestProp.Employee.OutOfOfficeBalance)
            {
                throw new Exception("OutOfOfficeBalance error");
            }
            
            item.LeaveRequestProp.Employee.OutOfOfficeBalance -= result;
            item.Approver = approver;
            item.Comment = comment;
            item.Status = ApprovalRequestStatus.Approve;
            item.LeaveRequestProp.Status = LeaveRequestStatus.Approve;
            await _context.SaveChangesAsync();
        }

        public async Task RejecctApprovalRequest(int approvalRequestId, int approver, string? comment)
        {
            var item = await _context.ApprovalRequests
                .Where(x => x.ID == approvalRequestId)
                .SingleOrDefaultAsync() ?? throw new Exception("not found");

            if (item.Status != ApprovalRequestStatus.New)
            {
                throw new Exception("status error");
            }

            item.Approver = approver;
            item.Comment = comment;
            item.Status = ApprovalRequestStatus.Rejected;
            item.LeaveRequestProp.Status = LeaveRequestStatus.Rejected;

            await _context.SaveChangesAsync();
        }


        public object GetAppravalRequestParameters()
        {
            var status = Enum.GetValues(typeof(ApprovalRequestStatus))
               .Cast<ApprovalRequestStatus>()
               .Select(x => new { name = x.ToString(), value = x })
               .ToList();

            return new
            {
                status,
            };
        }
    }
}
