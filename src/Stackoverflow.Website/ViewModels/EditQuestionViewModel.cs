using System.ComponentModel.DataAnnotations;

namespace Stackoverflow.Website.ViewModels
{
    public class EditQuestionViewModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public string Code { get; set; }
        public string Tags { get; set; }
    }
}
