using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OutOfOfficeData.Lists.Employees;

namespace OutOfOfficeData.Dto
{
    public record EmployeeForListDto(
        int ID, 
        string FullName, 
        int Subdivision,
        int Position,
        int Status,
        int PeopleParthner, 
        int OutOfOfficeBalance, 
        string? Photo
    );
}
