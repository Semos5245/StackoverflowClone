using System.ComponentModel.DataAnnotations;

namespace Stackoverflow.Website.ViewModels
{
    public class CreateJobViewModel
    {
        [Required]
        [StringLength(128)]
        public string Title { get; set; }

        [Required]
        [StringLength(1024)]
        public string Description { get; set; }

        [Required]
        [StringLength(128)]
        public string Role { get; set; }
        
        [Required]
        public string TechnologiesNeeded { get; set; }

        public decimal MinAnnualSalary { get; set; }
        public decimal MaxAnnualSalary { get; set; }
        public bool IsRemote { get; set; }
        public int Type { get; set; }
        public int ExperienceLevel { get; set; }

    }
}
