namespace Domain
{
    /// <summary>
    /// User info
    /// </summary>
    public class UserDeliveryInfo
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

        public Storage Storage { get; set; }

        /// <summary>
        /// User Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// User comment
        /// </summary>
        public string? Comment { get; set; }
      
    }
}
