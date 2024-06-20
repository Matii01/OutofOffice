using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestOutOfOfficeData.Dto;
using TestOutOfOfficeData.Extensions;
using TestOutOfOfficeData.Helper;
using TestOutOfOfficeData.Lists.Employees;
using TestOutOfOfficeData.Parameters;

namespace TestOutOfOfficeData.Services
{
    public class EmployeeService : BaseService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public EmployeeService(
            ApplicationDbContext context, 
            RoleManager<IdentityRole> roleManager, 
            UserManager<ApplicationUser> userManager) : base(context)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<List<EmployeeForListDto>> GetEmployeeList(EmployeeFilterParams param)
        {
            var list = await _context.Employees
                .Search(_context, param)
                .Select(x => new EmployeeForListDto(
                    x.ID,
                    x.FullName,
                    (int)x.Subdivision,
                    (int)x.Position,
                    (int)x.Status,
                    x.PeopleParthner,
                    x.OutOfOfficeBalance,
                    x.Photo
                    ))
                .ToListAsync();

            return list;
        }

        public async Task<object> GetNotInThisProjectEmployee(int projectId)
        {
            var employeeInProject = _context.EmployeeInProject.Where(x => x.ProjectID == projectId)
                .Select(x => x.EmployeeID)
                .ToArray();

            var list = await _context.Employees
                .Where(x => x.Position == EmployeePosition.Emplyee)
                .Where(x => !employeeInProject.Contains(x.ID))
                .ToListAsync();

            return list.Select(x => new
            {
                Id = x.ID,
                fullName = x.FullName,
            }).ToList();
        }


        public async Task<object> GetParametersForNewEmployee()
        {
            var subdivision = Enum.GetValues(typeof(Subdivision))
               .Cast<Subdivision>()
               .Select(x => new { name = x.ToString(), value = ((int)x) })
               .ToList();

            var position = Enum.GetValues(typeof(EmployeePosition))
              .Cast<EmployeePosition>()
              .Select(x => new { name = x.ToString(), value = ((int)x) })
              .ToList();

            var status = Enum.GetValues(typeof(EmployeesStatus))
                .Cast<EmployeesStatus>()
                .Select(x => new { name = x.ToString(), value = ((int)x) })
                .ToList();

            return new
            {
                subdivision,
                position,
                status,
                hrManagers = await GetHrManagerForSelect()
            };
        }

        public async Task<List<EmployeeForSelect>> GetHrManagerForSelect()
        {
            var hrManagers = await _context.Employees
                .Where(x => x.Position == EmployeePosition.HRManager)
                .Select(x => new EmployeeForSelect(x.ID, x.FullName))
                .ToListAsync();

            return hrManagers;
        }

        public async Task AddNewEmployee(NewEmployeeDto newEmployee, int peoplePartner)
        {
            var resutl = new NewEmployeeDto(
                    newEmployee.Email,
                    newEmployee.Password,
                    newEmployee.FullName,
                    newEmployee.Subdivision,
                    (int)EmployeePosition.Emplyee,
                    newEmployee.Status,
                    peoplePartner,
                    newEmployee.OutOfOfficeBalance,
                    newEmployee.Photo
                );

            await AddNewEmployee(resutl);
        }

        public async Task AddNewEmployee(NewEmployeeDto newEmployee)
        {
            var passwordHasher = new PasswordHasher<ApplicationUser>();

            ApplicationUser user = new()
            {
                UserName = newEmployee.Email,
                NormalizedUserName = newEmployee.Email.ToUpper(),
                Email = newEmployee.Email,
                NormalizedEmail = newEmployee.Email.ToUpper(),
                EmailConfirmed = true,
                PasswordHash = passwordHasher.HashPassword(null, newEmployee.Password),
                SecurityStamp = string.Empty,
                Employee = new Employee()
                {
                    FullName = newEmployee.FullName,
                    Subdivision = (Subdivision)newEmployee.Subdivision,
                    Position = (EmployeePosition)newEmployee.Position,
                    Status = (EmployeesStatus)newEmployee.Status,
                    PeopleParthner = newEmployee.PeopleParthner,
                    OutOfOfficeBalance = newEmployee.OutOfOfficeBalance,
                    Photo = newEmployee.Photo,
                },
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            await AssignRoleToUser(user, (EmployeePosition)newEmployee.Position);
        }

        public async Task EditEmployee(EditEmployeeDto newEmployee)
        {
            var toUpdate = await _context.Employees.FindAsync(newEmployee.ID) ?? throw new Exception("");

            if(!await HrManagerIsCorrectlyAssigned(newEmployee.Position, newEmployee.PeopleParthner))
            {
                throw new Exception("");
            }

            int oldRole = (int)toUpdate.Position;

            toUpdate.FullName = newEmployee.FullName;
            toUpdate.Subdivision = (Subdivision)newEmployee.Subdivision;
            toUpdate.Position = (EmployeePosition)newEmployee.Position;
            toUpdate.Status = (EmployeesStatus)newEmployee.Status;
            toUpdate.PeopleParthner = newEmployee.PeopleParthner;
            toUpdate.OutOfOfficeBalance = newEmployee.OutOfOfficeBalance;
            toUpdate.Photo = newEmployee.Photo;

            await _context.SaveChangesAsync();

            if(oldRole != newEmployee.Position)
            {
                await AssignRoleToUser(await FindUserByEmployeeId(newEmployee.ID), (EmployeePosition)newEmployee.Position);
            }
        }

        private async Task<bool> HrManagerIsCorrectlyAssigned(int position, int parthnerID)
        {
            if (position == (int)EmployeePosition.Emplyee || parthnerID != 0)
            {
                if (!await HrManagerExist(parthnerID))
                {
                    return false;
                }
            }
            return true;
        }

        private async Task<bool> HrManagerExist(int employeeId)
        {
            var employee = await _context.Employees.FindAsync(employeeId);

            if (employee is null)
            {
                return false;
            }

            return employee.Position == EmployeePosition.HRManager;
        }

        private async Task<ApplicationUser> FindUserByEmployeeId(int employeeId)
        {
            return await _context.Users
                .Where(x => x.EmployeeId ==  employeeId)
                .FirstOrDefaultAsync() ?? throw new Exception("");    
        }

        private async Task AssignRoleToUser(ApplicationUser user, EmployeePosition position)
        {
            var roles = await _userManager.GetRolesAsync(user);

            if (roles.Count > 0)
            {
                await _userManager.RemoveFromRolesAsync(user, roles); 
                _context.SaveChanges();
            }
            var role = EnumsConverter.EmployeePositionToRole(position);
            var result = await _userManager.AddToRoleAsync(user, role);
            _context.SaveChanges();
        }
    }
}
