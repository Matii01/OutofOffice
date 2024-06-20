using System.ComponentModel.DataAnnotations;

namespace OutOfOfficeData.Lists.Projects
{
    public class Project
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public ProjectType ProjectType { get; set; }
        
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public int ProjectManager {  get; set; }
        public string? Comment { get; set; }

        [Required]
        public ProjectStatus Status { get; set; }
    }
}
