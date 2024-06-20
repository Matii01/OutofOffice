using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestOutOfOfficeData.Lists.Employees
{
    public class IdentityUserEmployee
    {
        [Key]
        public int Id { get; set; }
        public string IdentityUserId { get; set; } = null!;
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;
    }
}
