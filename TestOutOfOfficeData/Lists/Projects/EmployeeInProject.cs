using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestOutOfOfficeData.Lists.Employees;

namespace TestOutOfOfficeData.Lists.Projects
{
    public class EmployeeInProject
    {
        [Key]
        public int ID { get; set; }

        public int EmployeeID { get; set; }
        public Employee Employee { get; set; } = null!;

        public int ProjectID { get; set; }
        public Project Project { get; set; } = null!;
    }
}
