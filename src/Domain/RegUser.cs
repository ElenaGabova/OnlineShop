using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class RegUser
    {
      

        /// <summary>
        /// User email
        /// </summary>
        [Required(ErrorMessage = "Не указана электронная почта!")]
        [EmailAddress(ErrorMessage = "Некоректный формат электронной почты!")]
        public string Email { get; set; }

        /// <summary>
        /// User phone
        /// </summary>
        [Required(ErrorMessage = "Не указан номер телефона пользователя!")]
        [RegularExpression(@"(?=.*\d).{10,11}$", ErrorMessage = "Номер телефона должен состоять из 10 или 11 символов!")]
        public string Phone { get; set; }

        /// <summary>
        /// User password
        /// </summary>
        [Required(ErrorMessage = "Не указан пароль пользователя!")]
        [RegularExpression(@"(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[\W]).{6,20}$",
        ErrorMessage = "Пароль должен состоять хотя бы из одной цифры, одной буквы, одной" +
            " заглавной буквы и одного символа, длина пароля должна быть больше 5 символов, и не превышать 20 символов")]
        public string Password { get; set; }

        /// <summary>
        /// User second password
        /// </summary>
        [Required(ErrorMessage = "Повторите пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string RepeadPassword { get; set; }
    }
}
