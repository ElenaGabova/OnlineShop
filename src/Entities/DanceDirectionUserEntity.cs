using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class DanceDirectionUserEntity
    {
        [Key]
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
