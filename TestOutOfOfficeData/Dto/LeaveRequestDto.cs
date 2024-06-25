using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OutOfOfficeData.Lists.Leave_Requests;

namespace OutOfOfficeData.Dto
{
    public class LeaveRequestDto
    {
        public int ID { get; set; }
        public string? EmployeeName { get; set; }
        public AbsenceReason AbsenceReason { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Comment { get; set; }
        public LeaveRequestStatus Status { get; set; }

        public LeaveRequestDto() { }

        public LeaveRequestDto(int id, string employeeName, AbsenceReason absenceReason, DateTime startDate, DateTime endDate, string? comment, LeaveRequestStatus status)
        {
            ID = id;
            EmployeeName = employeeName;
            AbsenceReason = absenceReason;
            StartDate = startDate;
            EndDate = endDate;
            Comment = comment;
            Status = status;
        }
    }
    //public record LeaveRequestDto(
    //    int ID, 
    //    string EmployeeName, 
    //    AbsenceReason AbsenceReason, 
    //    DateTime StartDate, 
    //    DateTime EndDate, 
    //    string? Comment, 
    //    LeaveRequestStatus Status
    //);
}
