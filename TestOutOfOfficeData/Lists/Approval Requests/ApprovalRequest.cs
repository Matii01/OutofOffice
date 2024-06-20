using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TestOutOfOfficeData.Lists.Leave_Requests;

namespace TestOutOfOfficeData.Lists.Approval_Requests
{
    public class ApprovalRequest
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey(nameof(ID))]
        public int Approver { get; set; }

        [ForeignKey(nameof(ID))]
        public int LeaverRequest {  get; set; }
        public LeaveRequest LeaveRequestProp { get; set; }
        public ApprovalRequestStatus Status { get; set; }
        public string? Comment { get; set; }
    }
}
