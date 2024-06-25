using AutoMapper;
using OutOfOfficeData.Dto;
using OutOfOfficeData.Lists.Leave_Requests;
using OutOfOfficeData.Lists.Projects;

namespace OutofOffice
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<NewLeaveRequestDto, LeaveRequest>()
                .ForMember(x => x.Status, opt => opt.MapFrom(x => LeaveRequestStatus.New))
                .AfterMap((src, dest, context) => dest.EmployeeId = context.Items["employeeId"] as int? ?? throw new Exception("UserId is required"));

            CreateMap<LeaveRequest, LeaveRequestDto>()
                .ForMember(x => x.EmployeeName, opt => opt.MapFrom(src => src.Employee.FullName));

            CreateMap<LeaveRequest, LeaveRequestForListDto>()
               .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => src.Employee.FullName))
               .ForMember(dest => dest.AbsenceReason, opt => opt.MapFrom(src => src.AbsenceReason.ToString()))
               .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

            CreateMap<Project, ProjectsForListDto>();
            CreateMap<Project, ProjectDto>();

            CreateMap<NewProjectDto, Project>()
                .AfterMap((src, dest, context) => dest.ProjectManager = context.Items["ProjectManager"] as int? ?? throw new Exception("ProjectManager is required"));

            CreateMap<NewProjectDto, Project>();
        }
    }
}
