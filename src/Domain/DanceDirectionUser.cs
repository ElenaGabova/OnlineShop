using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class DanceDirectionUser
    {
        /// <summary>
        /// DanceDirection user Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// DanceDirection user name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// DanceDirection User phone
        /// </summary>
        public string Phone { get; set; }
    }
}
