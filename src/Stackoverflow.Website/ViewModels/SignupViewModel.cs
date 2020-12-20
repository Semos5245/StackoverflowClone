using System.ComponentModel.DataAnnotations;

namespace Stackoverflow.Website.ViewModels
{
    public class SignupViewModel
    {
        [Required]
        public string DisplayName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
