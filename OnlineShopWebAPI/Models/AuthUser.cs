using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebAPI.Models
{
    public class AuthUser
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
