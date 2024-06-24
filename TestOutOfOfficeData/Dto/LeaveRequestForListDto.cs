using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OutOfOfficeData.Lists.Leave_Requests;

namespace OutOfOfficeData.Dto
{
    public class LeaveRequestForListDto
    {
        public int ID { get; set; }
        public string EmployeeName { get; set; }
        public string AbsenceReason { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Comment { get; set; }
        public string Status { get; set; }

        public LeaveRequestForListDto() 
        {
            EmployeeName = "";
            AbsenceReason = "";
            Status = "";
        }

        public LeaveRequestForListDto(int id, string employeeName, string absenceReason, DateTime startDate, DateTime endDate, string? comment, string status)
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
}
