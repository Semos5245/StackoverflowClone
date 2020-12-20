using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Stackoverflow.Website.BusinessModels
{
    public class AppUser : IdentityUser
    {
        #region Properties

        [Required]
        [StringLength(64)]
        public string DisplayName { get; set; }

        public bool IsBlocked { get; set; }

        #endregion
    }
}
