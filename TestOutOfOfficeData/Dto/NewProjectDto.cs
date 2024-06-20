using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestOutOfOfficeData.Lists.Projects;

namespace TestOutOfOfficeData.Dto
{
    public record NewProjectDto(
        ProjectType ProjectType,
        DateTime StartDate,
        DateTime? EndDate,
        int projectManager,
        string? Comment,
        ProjectStatus Status
    );
}
