using System.ComponentModel.DataAnnotations;

namespace Stackoverflow.Website.ViewModels
{
    public class CreateCommentViewModel
    {
        [Required]
        public string PostId { get; set; }

        [Required]
        public string Text { get; set; }
    }
}
