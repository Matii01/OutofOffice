using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestOutOfOfficeData.Lists.Projects;

namespace TestOutOfOfficeData.Dto
{
    public record ProjectsForListDto(
        int ID, 
        ProjectType ProjectType, 
        DateTime StartDate, 
        DateTime? EndDate, 
        int ProjectManager, 
        string? Text, 
        ProjectStatus Status
    );
}
