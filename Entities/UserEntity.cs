using Microsoft.AspNet.Identity.EntityFramework;

namespace Entities
{
    public class UserEntity : IdentityUser
    {
        /// <summary>
        /// User first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// User second name
        /// </summary>
        public string SecondName { get; set; }

        /// <summary>
        /// User File
        /// </summary>
        /// 
        public string ImagePath { get; set; }

    }
}
