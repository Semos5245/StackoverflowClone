using System;
using System.ComponentModel.DataAnnotations;

namespace Stackoverflow.Website.ViewModels
{
    public class EditCompanyViewModel
    {
        [Required]
        [StringLength(64)]
        public string Name { get; set; }

        [Required]
        [StringLength(256)]
        public string ShortQuote { get; set; }

        [Required]
        [StringLength(1024)]
        public string LongDescription { get; set; }

        [Required]
        public string TechStack { get; set; }

        [Required]
        public string Industry { get; set; }

        [Required]
        public string OfficeLocation { get; set; }

        [Required]
        [StringLength(128)]
        public string WebsiteUrl { get; set; }

        public int Size { get; set; }
        public DateTime Founded { get; set; }
    }
}
