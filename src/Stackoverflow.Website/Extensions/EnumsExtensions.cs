using Stackoverflow.Website.BusinessModels;

namespace Stackoverflow.Website.Extensions
{
    public static class EnumsExtensions
    {
        public static string ToDisplayString(this JobType type)
        {
            return type switch
            {
                JobType.FullTime => "Full-time",
                JobType.PartTime => "Part-time",
                JobType.TaskBased => "Task-based",
                _ => "Unidentified"
            };
        }

        public static string ToDisplayString(this ExperienceLevel level)
        {
            return level switch
            {
                ExperienceLevel.Junior => "Junior",
                ExperienceLevel.MidLevel => "Mid-level",
                ExperienceLevel.Senior => "Senior",
                _ => "Unidentified"
            };
        }
    }
}
