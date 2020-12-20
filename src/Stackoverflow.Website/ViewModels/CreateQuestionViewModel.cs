using System.ComponentModel.DataAnnotations;

namespace Stackoverflow.Website.ViewModels
{
    public class CreateQuestionViewModel
    {
        [Required]
        [StringLength(128)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public string Code { get; set; }

        public string Tags { get; set; }
    }
}
