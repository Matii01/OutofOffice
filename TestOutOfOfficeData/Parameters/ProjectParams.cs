using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestOutOfOfficeData.Lists.Projects;

namespace TestOutOfOfficeData.Parameters
{
    public class ProjectParams
    {
        public int? ProjectManagerId;
        public int? HrManagerId;
        public int? EmployeeId;
        public ProjectType[]? ProjectType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int[]? Managers { get; set; }
        public ProjectStatus[]? Statuses { get; set; }
    }
}
