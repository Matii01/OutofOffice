using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestOutOfOfficeData.Lists.Approval_Requests;
using TestOutOfOfficeData.Lists.Employees;
using TestOutOfOfficeData.Lists.Leave_Requests;
using TestOutOfOfficeData.Lists.Projects;
using TestOutOfOfficeData.Seeders;


namespace TestOutOfOfficeData
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {   
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApprovalRequest>()
                .HasOne(ar => ar.LeaveRequestProp)
                .WithMany()
                .HasForeignKey(ar => ar.LeaverRequest);

            //builder.ApplyConfiguration(new EmployeeSeeder());
            //builder.ApplyConfiguration(new RoleSeeder());
            //builder.ApplyConfiguration(new UserSeeder());
            //builder.ApplyConfiguration(new UserRoleSeeder());
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<ApprovalRequest> ApprovalRequests { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<EmployeeInProject> EmployeeInProject { get; set; }

    }
}
