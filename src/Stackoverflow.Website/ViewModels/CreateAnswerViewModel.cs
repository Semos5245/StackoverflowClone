
using System.ComponentModel.DataAnnotations;

namespace Stackoverflow.Website.ViewModels
{
    public class CreateAnswerViewModel
    {
        [Required]
        public string Description { get; set; }

        public string Code { get; set; }

        [Required]
        public string QuestionId { get; set; }
    }
}
