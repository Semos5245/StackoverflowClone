using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stackoverflow.Website.BusinessModels
{
    public class Company : BaseEntity
    {
        #region Properties

        [Required]
        [StringLength(64)]
        public string Name { get; set; }

        [Required]
        [StringLength(256)]
        public string ShortQuote { get; set; }

        [Required]
        public string LongDescription { get; set; }

        [Required]
        [StringLength(128)]
        public string LogoFileName { get; set; }

        [Required]
        public string TechStack { get; set; }

        public string OfficeLocation { get; set; }

        [Required]
        public string Industry { get; set; }

        [Required]
        [StringLength(128)]
        public string WebsiteUrl { get; set; }

        public int Views { get; set; }
        public int Size { get; set; }

        public DateTime Founded { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        #endregion

        #region Navigation Properties

        public virtual AppUser User { get; set; }

        public virtual IList<Job> Jobs { get; set; }

        #endregion
    }
}
