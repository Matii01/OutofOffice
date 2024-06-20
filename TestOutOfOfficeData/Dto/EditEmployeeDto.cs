using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOfficeData.Dto
{
    public record EditEmployeeDto(
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
