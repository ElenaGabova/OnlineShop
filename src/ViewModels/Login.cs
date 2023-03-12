using OnlineShopWebApp.Constants;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Areas.Autorization.Models
{
    /// <summary>
    /// Class for login user
    /// </summary>
    public class Login
    {
        /// <summary>
        /// User name
        /// </summary>
        [Required(ErrorMessage = WebAppConstants.RequiredValidationLoginErrorText)]
        [EmailAddress(ErrorMessage = WebAppConstants.EmailAddressValidationErrorText)]
        public string UserName { get; set; }

        private string _password;

        /// <summary>
        /// User password
        /// </summary>
        [Required(ErrorMessage = WebAppConstants.RequiredValidationPasswordErrorText)]
        public string Password
        {
            get
            {
                return this._password.Trim();
            }
            set
            {
                _password = value.Trim();
            }
        }

    /// <summary>
    /// Remember user
    /// </summary>
    public bool RememberMe { get; set; }

        /// <summary>
        /// Return url
        /// </summary>
        public string? ReturnUrl { get; set; }
    }
}
