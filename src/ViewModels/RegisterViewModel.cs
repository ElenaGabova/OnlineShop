using Microsoft.AspNetCore.Http;
using OnlineShopWebApp.Constants;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Areas.Autorization.Models
{
    /// <summary>
    /// Class for login user
    /// </summary>
    public class RegisterViewModel
    {
        private string _password;
        private string _password2;

        /// <summary>
        /// User first name
        /// </summary>
        [Required(ErrorMessage = WebAppConstants.RequiredValidationFirstNameErrorText)]
        public string FirstName { get; set; }

        /// <summary>
        /// User second name
        /// </summary>
        [Required(ErrorMessage = WebAppConstants.RequiredValidationSecondNameErrorText)]
        public string SecondName { get; set; }


        /// <summary>
        /// User name
        /// </summary>
        [Required(ErrorMessage = WebAppConstants.RequiredValidationLoginErrorText)]
        [EmailAddress(ErrorMessage = WebAppConstants.EmailAddressValidationErrorText)]
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
        public string SecondPassword
        {
            get
            {
                return this._password2;
            }
              set
            {
                _password2 = value?.Trim();
            }
        }


        [Required(ErrorMessage = WebAppConstants.RequiredValidationUserInfoPhoneErrorText)]
        [RegularExpression(@"(?=.*\d).{10,11}$", ErrorMessage = WebAppConstants.PhoneRegularExpressioRegularExpression)]
        /// <summary>
        /// Phone Number
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// User File
        /// </summary>
        public IFormFile? UploadedFile { get; set; }

        /// <summary>
        /// Path of image
        /// </summary>
        public string? ImagePath { get; set; }

        /// <summary>
        /// Return url
        /// </summary>
        public string? ReturnUrl { get; set; }

        public RegisterViewModel() { }

        public RegisterViewModel(string firstName, string secondName, string userName, string phoneNumber, string password, string secondPassword)
        {
            FirstName = firstName;
            SecondName = secondName;
            UserName = userName;
            PhoneNumber = phoneNumber;
            Password = password;
            SecondPassword = secondPassword;
        }
    }
}
