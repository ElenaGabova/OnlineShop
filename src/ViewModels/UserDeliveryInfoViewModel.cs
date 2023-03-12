using OnlineShopWebApp.Constants;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ViewModels
{
    /// <summary>
    /// User info
    /// </summary>
    public class UserDeliveryInfoViewModel
    {
        /// <summary>
        /// User id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// User Name
        /// </summary>
        /// 
        [Required(ErrorMessage = WebAppConstants.RequiredValidationUserInfoNameErrorText)]
        public string Name { get; set; }

        [Required(ErrorMessage = WebAppConstants.RequiredValidationUserInfoPhoneErrorText)]
        [RegularExpression(@"(?=.*\d).{10,11}$", ErrorMessage = WebAppConstants.PhoneRegularExpressioRegularExpression)]
        /// <summary>
        /// Phone Number
        /// </summary>
        public string PhoneNumber { get; set; }


        [Required(ErrorMessage = WebAppConstants.RequiredValidationUserInfoEmailErrorText)]
        [EmailAddress(ErrorMessage = WebAppConstants.InfoNameEmailAddressValidationErrorText)]
        /// <summary>
        /// User Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// User comment
        /// </summary>
        public string? Comment { get; set; }

        public UserDeliveryInfoViewModel() { }

        /// <summary>
        /// Constructor for deserialize from json
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        /// <param name="storageItemsCollection"></param>
        [JsonConstructorAttribute]
        public UserDeliveryInfoViewModel(string id, string name, string phoneNumber, string email, string comment = "")
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
            Comment = comment;
        }

    }
}
