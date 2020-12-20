using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stackoverflow.Website.BusinessModels
{
    public class Question : TimedEntity
    {
        #region Properties

        [Key]
        [ForeignKey(nameof(Post))]
        public string Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Title { get; set; }

        public string Tags { get; set; }
        public int Views { get; set; }

        #endregion

        #region Navigation Properties

        public virtual Post Post { get; set; }
        
        #endregion
    }
}
