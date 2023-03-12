using OnlineShopWebApp.Constants;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Areas.Admin.Models
{
    /// <summary>
    /// Class for change password
    /// </summary>
    public class ChangePassword
    {
        private string _password;

        /// <summary>
        /// User name
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// User password
        /// </summary>
        [Required(ErrorMessage = WebAppConstants.RequiredValidationPasswordErrorText)]
        [RegularExpression(@"(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[\W]).{6,20}$",
            ErrorMessage = WebAppConstants.PasswordRegularExpressionErrorText)]
        public string Password
        {
            get
            {
                return this._password;
            }
            set
            {
                _password = value?.Trim();
            }
        }

        /// <summary>
        /// User second password
        /// </summary>
        [Compare("Password", ErrorMessage = WebAppConstants.RegistretionNotComparePasswordErrorText)]
        public string SecondPassword { get; set; }
    }
}
