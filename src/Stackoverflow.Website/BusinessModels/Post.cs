using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stackoverflow.Website.BusinessModels
{
    public class Post : BaseEntity
    {
        #region Properties

        [Required]
        public string Description { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        #endregion

        #region Navigation Properties

        public virtual AppUser User { get; set; }
        
        #endregion
    }
}
