using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stackoverflow.Website.BusinessModels
{
    public class Vote : BaseEntity
    {
        #region Properties

        public bool IsUpVote { get; set; }

        [Required]
        [ForeignKey(nameof(Post))]
        public string PostId { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        #endregion

        #region Navigation Properties

        public virtual Post Post { get; set; }

        public virtual AppUser User { get; set; }
        
        #endregion
    }
}
