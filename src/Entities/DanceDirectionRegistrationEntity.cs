using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class DanceDirectionRegistrationEntity
    {
        [Key]
        public Guid Id { get; set; }
        /// <summary>
        /// CreatedDateTime 
        /// </summary>
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        /// <summary>
        /// Dance Direction
        /// </summary>
        public DanceDirectionEntity DanceDirectionEntity { get; set; }
        /// <summary>
        /// Dance Direction user
        /// </summary>
        public DanceDirectionUserEntity DanceDirectionUserEntity { get; set; }
        /// <summary>
        /// Need to call to user
        /// </summary>
        public bool NeedToCall { get; set; } = false;
    }
}
