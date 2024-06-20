using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TestOutOfOfficeData.Lists.Employees;


namespace TestOutOfOfficeData.Seeders
{
    public class UserSeeder : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var passwordHasher = new PasswordHasher<ApplicationUser>();

            var users = new List<ApplicationUser>
            {
                new ()
                {
                    Id = "b75aac86-370d-4bd8-a51c-e426591a4dd5",
                    UserName = "employee@example.com",
                    NormalizedUserName = "EMPLOYEE@EXAMPLE.COM",
                    Email = "employee@example.com",
                    NormalizedEmail = "EMPLOYEE@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = passwordHasher.HashPassword(null, "Pa$$word1000"),
                    SecurityStamp = string.Empty,
                    EmployeeId = 1
                },
                new ()
                {
                    Id = "a6d6def5-a80e-4c63-ac5a-07ec81797553",
                    UserName = "hrmanager@example.com",
                    NormalizedUserName = "HRMANAGER@EXAMPLE.COM",
                    Email = "hrmanager@example.com",
                    NormalizedEmail = "HRMANAGER@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = passwordHasher.HashPassword(null, "Pa$$word1000"),
                    SecurityStamp = string.Empty,
                     EmployeeId = 2
                },
                new ()
                {
                    Id = "bb32cd38-9129-43ca-bb89-fcc0b5d6c1a3",
                    UserName = "projectmanager@example.com",
                    NormalizedUserName = "PROJECTMANAGER@EXAMPLE.COM",
                    Email = "projectmanager@example.com",
                    NormalizedEmail = "PROJECTMANAGER@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = passwordHasher.HashPassword(null, "Pa$$word1000"),
                    SecurityStamp = string.Empty,
                    EmployeeId = 3
                },
                new ()
                {
                    Id = "b863d404-b85b-49cf-acf8-4f3e85d501bb",
                    UserName = "administrator@example.com",
                    NormalizedUserName = "ADMINISTRATOR@EXAMPLE.COM",
                    Email = "administrator@example.com",
                    NormalizedEmail = "ADMINISTRATOR@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = passwordHasher.HashPassword(null, "Pa$$word1000"),
                    SecurityStamp = string.Empty,
                    EmployeeId = 4
                }
            };

            builder.HasData(users);
        }
    }
}
