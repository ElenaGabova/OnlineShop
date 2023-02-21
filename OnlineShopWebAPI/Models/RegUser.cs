using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebAPI.Models
{
    public class RegUser
    {
        [Required(ErrorMessage = "Укажите email")]
        [EmailAddress(ErrorMessage = "Указан некорректный email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Укажите телефон")]
        [Phone(ErrorMessage = "Указан некорректный номер телефона")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Укажите пароль")]
        [StringLength(25, MinimumLength = 6, ErrorMessage = "Длина пароля должна быть от 6 до 25 символов")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Повторите пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string RepeadPassword { get; set; }
    }
}
