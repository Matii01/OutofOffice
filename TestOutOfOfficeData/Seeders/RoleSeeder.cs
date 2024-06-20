using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace OutOfOfficeData.Seeders
{
    public class RoleSeeder : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                 new IdentityRole
                 {
                     Id = "6ddc9cec-043f-4cf4-a09e-a1635c556b09",
                     Name = "Employee",
                     NormalizedName = "EMPLOYEE"
                 },
                 new IdentityRole
                 {
                     Id = "82bde306-d74a-498a-850b-c7ed5b2e5b01",
                     Name = "HRManager",
                     NormalizedName = "HRMANAGER"
                 },
                 new IdentityRole
                 {
                     Id = "cbb40b0d-048c-4e46-b4b6-8912d146d1c6",
                     Name = "ProjectManager",
                     NormalizedName = "PROJECTMANAGER"
                 },
                 new IdentityRole
                 {
                     Id = "5ac784c4-ce4c-46ac-9de5-738511d27b90",
                     Name = "Administrator",
                     NormalizedName = "ADMINISTRATOR"
                 }
            );
        }
    }
}

/*
 builder.HasData(
                 new IdentityRole
                 {
                     Id = "6ddc9cec-043f-4cf4-a09e-a1635c556b09",
                     Name = "Employee",
                     NormalizedName = "EMPLOYEE"
                 },
                 new IdentityRole
                 {
                     Id = "82bde306-d74a-498a-850b-c7ed5b2e5b01",
                     Name = "HRManager",
                     NormalizedName = "HRMANAGER"
                 },
                 new IdentityRole
                 {
                     Id = "cbb40b0d-048c-4e46-b4b6-8912d146d1c6",
                     Name = "ProjectManager",
                     NormalizedName = "PROJECTMANAGER"
                 },
                 new IdentityRole
                 {
                     Id = "5ac784c4-ce4c-46ac-9de5-738511d27b90",
                     Name = "Administrator",
                     NormalizedName = "ADMINISTRATOR"
                 }
            );
 */