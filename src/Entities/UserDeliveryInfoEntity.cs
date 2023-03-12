namespace Entities
{
    /// <summary>
    /// User info
    /// </summary>
    public class UserDeliveryInfoEntity
    {
        /// <summary>
        /// User id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// User Name
        /// </summary>
        /// 
        public string Name { get; set; }

        /// <summary>
        /// Phone Number
        /// </summary>
        public string PhoneNumber { get; set; }

        public StorageEntity? Storage { get; set; }

        /// <summary>
        /// User Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// User comment
        /// </summary>
        public string? Comment { get; set; }

        /// <summary>
        /// Constructor for user from View
        /// </summary>
        public UserDeliveryInfoEntity()
        {
            Id = "0";
        }

        public UserDeliveryInfoEntity(string id, string name, string phoneNumber, string email, string comment = "")
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
            Comment = comment;
        }
    }
}
