using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestOutOfOfficeData.Lists.Projects;

namespace TestOutOfOfficeData.Dto
{
    public record ProjectDto(
        int ID,
        ProjectType ProjectType,
        DateTime StartDate,
        DateTime? EndDate,
        int ProjectManager,
        string? Comment,
        ProjectStatus Status
    );
}
