using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stackoverflow.Website.BusinessModels
{
    public class Comment : BaseEntity
    {
        #region Properties

        [Required]
        public string Description { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        [Required]
        [ForeignKey(nameof(Post))]
        public string PostId { get; set; }

        #endregion

        #region Navigation Properties

        public virtual AppUser User { get; set; }
        public virtual Post Post { get; set; }

        #endregion
    }
}
