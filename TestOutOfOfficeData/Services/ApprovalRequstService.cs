﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OutOfOfficeData.Dto;
using OutOfOfficeData.Exceptions;
using OutOfOfficeData.Extensions;
using OutOfOfficeData.Lists.Approval_Requests;
using OutOfOfficeData.Lists.Leave_Requests;
using OutOfOfficeData.NewFolder;
using OutOfOfficeData.Parameters;

namespace OutOfOfficeData.Services
{
    public class ApprovalRequstService : BaseService
    {
        public ApprovalRequstService(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
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
                .SingleOrDefaultAsync() ?? throw new NotFoundException("approval request not found");

            return approvalRequest;
        }

        public async Task AcceptApprovalRequest(int approvalRequestId, int approver, string? comment)
        {
            var item = await _context.ApprovalRequests
                .Include(x => x.LeaveRequestProp)
                .ThenInclude(x => x.Employee)
                 .Where(x => x.ID == approvalRequestId)
                 .SingleOrDefaultAsync() ?? throw new NotFoundException("approval request not found");

            if(item.Status != ApprovalRequestStatus.New)
            {
                throw new BadRequestException("status error");
            }

            var start = item.LeaveRequestProp.StartDate;
            var end = item.LeaveRequestProp.EndDate;
            var result = (end - start).Days;

            if(result > item.LeaveRequestProp.Employee.OutOfOfficeBalance)
            {
                throw new BadRequestException("OutOfOfficeBalance error");
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
                .SingleOrDefaultAsync() ?? throw new NotFoundException("approval request not found");

            if (item.Status != ApprovalRequestStatus.New)
            {
                throw new BadRequestException("status error");
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
