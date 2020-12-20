using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stackoverflow.Website.BusinessModels
{
    public class Answer : TimedEntity
    {
        #region Properties

        [Key]
        [ForeignKey(nameof(Post))]
        public string Id { get; set; }
        public bool IsAccepted { get; set; }

        [Required]
        [ForeignKey(nameof(Question))]
        public string QuestionId { get; set; }

        #endregion

        #region Navigation Properties

        public virtual Question Question { get; set; }
        public virtual Post Post { get; set; }

        #endregion
    }
}
