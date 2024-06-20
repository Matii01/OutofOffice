using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestOutOfOfficeData.Dto
{
    public record NewEmployeeDto(
            string Email,
            string Password,
            string FullName,
            int Subdivision,
            int Position,
            int Status,
            int PeopleParthner,
            int OutOfOfficeBalance,
            string? Photo
        );
}
