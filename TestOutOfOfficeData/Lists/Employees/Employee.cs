using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeData.Lists.Employees
{
    public class Employee 
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string FullName { get; set; } = null!;

        [Required]
        public Subdivision Subdivision { get; set; }

        [Required]
        public EmployeePosition Position { get; set; } 

        [Required]
        public EmployeesStatus Status { get; set; }

        [ForeignKey(nameof(ID))]
        [Required]
        public int PeopleParthner { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int OutOfOfficeBalance { get; set; }

        public string? Photo {get; set; }
    }
}
