using OnlineShopWebApp.Constants;
using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class DanceDirectionUserViewModel
    {
        [Key]
        /// <summary>
        /// DanceDirection user Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// DanceDirection user name
        /// </summary>      
        [Required(ErrorMessage = WebAppConstants.RequiredValidationUserInfoNameErrorText)]
        public string Name { get; set; }

        /// <summary>
        /// DanceDirection User phone
        /// </summary>
        ///  
        [Required(ErrorMessage = WebAppConstants.RequiredValidationUserInfoPhoneErrorText)]
        [RegularExpression(@"(?=.*\d).{10,11}$", ErrorMessage = WebAppConstants.PhoneRegularExpressioRegularExpression)]
        public string Phone { get; set; }
    }
}
