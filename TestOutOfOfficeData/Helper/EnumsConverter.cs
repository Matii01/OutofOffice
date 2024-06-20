using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OutOfOfficeData.Lists.Employees;

namespace OutOfOfficeData.Helper
{
    public static class EnumsConverter
    {
        public static string ConvertSubdivisioner(Subdivision subdivision)
        {
            switch (subdivision)
            {
                case Subdivision.Administration:
                    return "Administration";
                case Subdivision.HumanResources:
                    return "Human Resources";
                case Subdivision.Marketing:
                    return "Marketing";
                case Subdivision.Finance:
                    return "Finance";
                case Subdivision.ResearchAndDevelopment:
                    return "Research And Development";
                case Subdivision.CustomerSupport:
                    return "Customer Support";
                default:
                    break;
            }

            return "";
        }

        public static string EmployeePositionConverter(EmployeePosition subdivision) => subdivision switch
        {
            EmployeePosition.Emplyee => "Emplyee",
            EmployeePosition.HRManager => "HR Manager",
            EmployeePosition.ProjectManager => "Project Manager",
            EmployeePosition.Administrator => "Administrator",
            _=> throw new ArgumentOutOfRangeException(nameof(subdivision)),
        };

        public static string EmployeePositionToRole(EmployeePosition subdivision) => subdivision switch
        {
            EmployeePosition.Emplyee => "Employee",
            EmployeePosition.HRManager => "HRManager",
            EmployeePosition.ProjectManager => "ProjectManager",
            EmployeePosition.Administrator => "Administrator",
            _ => throw new ArgumentOutOfRangeException(nameof(subdivision)),
        };
    }
}
