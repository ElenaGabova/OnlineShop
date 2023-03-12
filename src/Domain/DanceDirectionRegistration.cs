using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class DanceDirectionRegistration
    {
        public Guid Id { get; set; }
        /// <summary>
        /// CreatedDateTime 
        /// </summary>
        public DateTime CreatedDateTime { get; set; }
        /// <summary>
        /// Dance Direction
        /// </summary>
        public DanceDirection DanceDirection { get; set; }
        /// <summary>
        /// Dance Direction user
        /// </summary>
        public DanceDirectionUser DanceDirectionUser { get; set; }
        /// <summary>
        /// Need to call to user
        /// </summary>
        public bool NeedToCall { get; set; } = false;
      
    }
}
