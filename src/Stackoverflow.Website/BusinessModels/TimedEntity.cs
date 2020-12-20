using System;

namespace Stackoverflow.Website.BusinessModels
{
    public class TimedEntity
    {
        #region Properties

        public DateTime CreatedDateUtc { get; set; }
        public DateTime EditedDateUtc { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public TimedEntity()
        {
            CreatedDateUtc = EditedDateUtc = DateTime.UtcNow;
        }
        
        #endregion
    }
}
