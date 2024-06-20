using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeData.Parameters
{
    public class EmployeeFilterParams
    {
        public int? ProjectManagerId;
        public int? HrManagerId;
        public string? FullName { get; set; }
        public int[]? SubdivisionId { get; set; }
        public int[]? PositionId { get; set; }
        public int[]? StatusId { get; set; }
        public int[]? PeopleParthner { get; set; }
        public int? OutOfOfficeBalanceMin { get; set; }
        public int? OutOfOfficeBalanceMax { get; set; }
    }
}
