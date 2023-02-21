using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class DanceDirectionRegistrationViewModel
    {
        public Guid Id { get; set; }

        /// <summary>
        /// CreatedDateTime 
        /// </summary>
        /// 

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        /// <summary>
        /// Dance Direction
        /// </summary>
        public DanceDirectionViewModel DanceDirection { get; set; }
        /// <summary>
        /// Dance Direction user
        /// </summary>
        public DanceDirectionUserViewModel DanceDirectionUser { get; set; }
        /// <summary>
        /// Need to call to user
        /// </summary>
        public bool NeedToCall { get; set; } = false;
    }
}
