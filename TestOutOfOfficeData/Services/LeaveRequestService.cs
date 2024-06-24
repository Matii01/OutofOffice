using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OutOfOfficeData.Dto;
using OutOfOfficeData.Extensions;
using OutOfOfficeData.Lists.Approval_Requests;
using OutOfOfficeData.Lists.Leave_Requests;
using OutOfOfficeData.Lists.Projects;
using OutOfOfficeData.Parameters;
using OutOfOfficeData.NewFolder;
using OutOfOfficeData.Exceptions;

namespace OutOfOfficeData.Services
{
    public class LeaveRequestService : BaseService
    {
        public LeaveRequestService(ApplicationDbContext context) 
            : base(context) 
        {
        }

        public async Task<List<LeaveRequestForListDto>> GetLeaveRequests(LeaveRequestParams param)
        {
            var list = await _context.LeaveRequests.Search(_context, param)
                .Select(x => new LeaveRequestForListDto(
                    x.ID,
                    x.Employee.FullName,
                    x.AbsenceReason.ToString(),
                    x.StartDate,
                    x.EndDate,
                    x.Comment,
                    x.Status.ToString()
                    ))
                .ToListAsync();

            return list;
        }
        public async Task<LeaveRequestDto> GetLeaveRequestDetails(int leaveRequestId)
        {
            var leaveRequest = await _context.LeaveRequests
                .Include(x => x.Employee)
                .Where(x => x.ID == leaveRequestId)
                .SingleOrDefaultAsync() ?? throw new NotFoundException("leave request not found");

            var item = new LeaveRequestDto(
                leaveRequest.ID,
                leaveRequest.Employee.FullName,
                leaveRequest.AbsenceReason,
                leaveRequest.StartDate,
                leaveRequest.EndDate,
                leaveRequest.Comment,
                leaveRequest.Status
            );

            return item;
        }
        public async Task<LeaveRequest> CreateLeaveRequest(int employeeId, NewLeaveRequestDto newLeaveRequest)
        {
            LeaveRequest leaveRequest = new()
            {
                EmployeeId = employeeId,
                AbsenceReason = newLeaveRequest.AbsenceReason,
                StartDate = newLeaveRequest.StartDate,
                EndDate = newLeaveRequest.EndDate,
                Comment = newLeaveRequest.Comment,
                Status = LeaveRequestStatus.New,
            };

            _context.LeaveRequests.Add(leaveRequest);
            await _context.SaveChangesAsync();
            return leaveRequest;
        }

        public async Task<LeaveRequest> SubmiteLeaveRequest(int leaveRequestId, int employeeId)
        {
            var leaveReuest = await _context.LeaveRequests.FindAsync(leaveRequestId) 
                ?? throw new NotFoundException("leave request not found");

            if (leaveReuest.Status != LeaveRequestStatus.New)
            {
                throw new BadRequestException("the request was sent");
            }
           
            ApprovalRequest approvalRequest = new()
            {
                LeaverRequest = leaveReuest.ID,
                Status = ApprovalRequestStatus.New
            };

            leaveReuest.Status = LeaveRequestStatus.Submitted;
            _context.ApprovalRequests.Add(approvalRequest);
            
            await _context.SaveChangesAsync();

            return leaveReuest;
        }

        public async Task<LeaveRequest> CancelLeaveRequest(int leaveRequestId)
        {
            var leaveReuest = await _context.LeaveRequests.FindAsync(leaveRequestId) 
                ?? throw new NotFoundException("leave request not found");

            var approvalRequest = await _context.ApprovalRequests
                .Where(x => x.LeaverRequest == leaveRequestId)
                .SingleOrDefaultAsync();

            if(approvalRequest != null)
            {
                approvalRequest.Status = ApprovalRequestStatus.Canceled;
            }
            leaveReuest.Status = LeaveRequestStatus.Canceled;

            await _context.SaveChangesAsync();
            return leaveReuest;
        }

        public object GetLeaveRequestParameters()
        {
            var status = Enum.GetValues(typeof(LeaveRequestStatus))
               .Cast<LeaveRequestStatus>()
               .Select(x => new { name = x.ToString(), value = x })
               .ToList();

            var absenceReason = Enum.GetValues(typeof(AbsenceReason))
              .Cast<AbsenceReason>()
              .Select(x => new { name = x.ToString(), value = x })
              .ToList();

            return new
            {
                absenceReason,
                status,
            };
        }
    }
}
