using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeData.Dto
{
    public record ApprovalRequstForListDto(
        int ID,
        string Requester,
        string? Approver,
        string Status
   );
}
