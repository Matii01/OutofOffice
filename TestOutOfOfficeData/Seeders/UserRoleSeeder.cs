using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace OutOfOfficeData.Seeders
{
    public class UserRoleSeeder : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    UserId = "b75aac86-370d-4bd8-a51c-e426591a4dd5",
                    RoleId = "6ddc9cec-043f-4cf4-a09e-a1635c556b09" // employee
                },
                new IdentityUserRole<string>
                {
                    UserId = "a6d6def5-a80e-4c63-ac5a-07ec81797553", 
                    RoleId = "82bde306-d74a-498a-850b-c7ed5b2e5b01" // hr
                },
                new IdentityUserRole<string>
                {
                    UserId = "bb32cd38-9129-43ca-bb89-fcc0b5d6c1a3",
                    RoleId = "cbb40b0d-048c-4e46-b4b6-8912d146d1c6" // PM
                },
                new IdentityUserRole<string>
                {
                    UserId = "b863d404-b85b-49cf-acf8-4f3e85d501bb",  
                    RoleId = "5ac784c4-ce4c-46ac-9de5-738511d27b90" // Admin
                }
            );
        }
    }
}
