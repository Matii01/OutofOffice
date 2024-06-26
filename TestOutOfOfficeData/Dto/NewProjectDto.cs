﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OutOfOfficeData.Lists.Projects;

namespace OutOfOfficeData.Dto
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
