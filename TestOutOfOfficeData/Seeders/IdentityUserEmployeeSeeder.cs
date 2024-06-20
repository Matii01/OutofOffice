using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OutOfOfficeData.Lists.Employees;

namespace OutOfOfficeData.Seeders
{
    public class IdentityUserEmployeeSeeder : IEntityTypeConfiguration<IdentityUserEmployee>
    {
        public void Configure(EntityTypeBuilder<IdentityUserEmployee> builder)
        {
            builder.HasData(
                 new IdentityUserEmployee
                 {
                     IdentityUserId = "b75aac86-370d-4bd8-a51c-e426591a4dd5",
                     Employee = new Employee
                     {
                         ID = 1,
                         FullName = "Full Name",
                         Position = EmployeePosition.Emplyee,
                         Status = EmployeesStatus.Active,
                         PeopleParthner = 2,
                     }
                 },
                 new IdentityUserEmployee
                 {
                     IdentityUserId = "a6d6def5-a80e-4c63-ac5a-07ec81797553",
                     Employee = new Employee
                     {
                         ID = 2,
                         FullName = "Test",
                         Position = EmployeePosition.HRManager,
                         Status = EmployeesStatus.Active,
                     }
                 },
                 new IdentityUserEmployee
                 {
                     IdentityUserId = "bb32cd38-9129-43ca-bb89-fcc0b5d6c1a3",
                     Employee = new Employee
                     {
                         FullName = "Test",
                         Position = EmployeePosition.ProjectManager,
                         Status = EmployeesStatus.Active,
                     }
                 },
                 new IdentityUserEmployee
                 {
                     IdentityUserId = "b863d404-b85b-49cf-acf8-4f3e85d501bb",
                     Employee = new Employee
                     {
                         FullName = "Test",
                         Position = EmployeePosition.Administrator,
                         Status = EmployeesStatus.Active,
                     }
                 }
            );
        }
    }
}
