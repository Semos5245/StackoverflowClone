using System;

namespace Stackoverflow.Website.ViewModels
{
    public class JobDetailsViewModel
    {
        public string Id { get; set; }
        public DateTime CreatedFromUtc { get; set; }
        public string Title { get; set; }
        public string CompanyName { get; set; }
        public string CompanyLogoFileName { get; set; }
        public int CompanySize { get; set; }
        public string Industry { get; set; }
        public string TechnologiesNeeded { get; set; }
        public decimal MinAnnualSalary { get; set; }
        public decimal MaxAnnualSalary { get; set; }
        public bool IsRemote { get; set; }
        public string Type { get; set; }
        public string ExperienceLevel { get; set; }
        public string Description { get; set; }
        public string Role { get; set; }
        public bool CanModifyJob { get; set; }
        public string CompanyLocation { get; set; }
    }
}
