using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stackoverflow.Website.BusinessModels
{
    public class Job : BaseEntity
    {
        #region Properties

        [Required]
        [StringLength(128)]
        public string Title { get; set; }

        [Column(TypeName = "decimal(8, 2)")]
        public decimal MinAnnualSalary { get; set; }

        [Column(TypeName = "decimal(8, 2)")]
        public decimal MaxAnnualSalary { get; set; }
        public bool IsRemote { get; set; }

        [Required]
        public string TechnologiesNeeded { get; set; }
        public int Views { get; set; }
        public int TypeId { get; set; }
        public int ExperienceLevelId { get; set; }

        [NotMapped]
        public JobType Type 
        {
            get => (JobType)TypeId;
            set => TypeId = (int)value;
        }

        [NotMapped]
        public ExperienceLevel ExperienceLevel
        {
            get => (ExperienceLevel)ExperienceLevelId;
            set => ExperienceLevelId = (int)value;
        }

        [Required]
        public string Description { get; set; }

        [Required]
        [StringLength(128)]
        public string Role { get; set; }

        [Required]
        [ForeignKey(nameof(Company))]
        public string CompanyId { get; set; }

        #endregion

        #region Navigation Properties

        public virtual Company Company { get; set; }
        
        #endregion
    }
}
