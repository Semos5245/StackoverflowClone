using System.ComponentModel.DataAnnotations;

namespace Stackoverflow.Website.ViewModels
{
    public class EditAnswerViewModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Description { get; set; }

        public string Code { get; set; }
    }
}
