using System;
using System.ComponentModel.DataAnnotations;

namespace Stackoverflow.Website.BusinessModels
{
    public abstract class BaseEntity : TimedEntity
    {
        #region Properties

        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        #endregion
    }
}
