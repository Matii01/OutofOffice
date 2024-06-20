using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using OutOfOfficeData.Lists.Employees;

namespace OutOfOfficeData.Lists.Leave_Requests
{
    public class LeaveRequest
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey(nameof(ID))]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;

        public AbsenceReason AbsenceReason { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public string? Comment { get; set; }
        public LeaveRequestStatus Status { get; set; }
    }
}
