using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OutOfOfficeData.Lists.Employees;

namespace OutOfOfficeData.Seeders
{
    public class EmployeeSeeder : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData(
                new Employee
                {
                    ID = 1,
                    FullName = "Full Name",
                    Subdivision = Subdivision.ResearchAndDevelopment,
                    Position = EmployeePosition.Emplyee,
                    Status = EmployeesStatus.Active,
                    PeopleParthner = 2,
                },
                new Employee
                {
                    ID = 2,
                    FullName = "Test",
                    Subdivision = Subdivision.HumanResources,
                    Position = EmployeePosition.HRManager,
                    Status = EmployeesStatus.Active,
                },
                new Employee
                {
                    ID = 3,
                    FullName = "Test",
                    Subdivision = Subdivision.ResearchAndDevelopment,
                    Position = EmployeePosition.ProjectManager,
                    Status = EmployeesStatus.Active,
                    PeopleParthner = 2,
                },
                new Employee
                {
                    ID = 4,
                    FullName = "Test",
                    Subdivision = Subdivision.Administration,
                    Position = EmployeePosition.Administrator,
                    Status = EmployeesStatus.Active,
                    PeopleParthner = 2,
                }
            );          
        }
    }
}
