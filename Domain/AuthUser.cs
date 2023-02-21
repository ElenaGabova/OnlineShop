using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class AuthUser
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
