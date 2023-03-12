using Domain;

namespace Service
{
    public interface IUserDeliveryInfoService
    {
        /// <summary>
        /// Add new User
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPhone"></param>
        Task AddAsync(string userName, string userPhone, string adress);

        /// <summary>
        /// Update info about User
        /// </summary>
        /// <param name="curentUserInfo">curent User id</param>
        /// <param name="newUserInfo">new UserInfo</param>
        Task<UserDeliveryInfo> UpdateAsync(string curentUserId, UserDeliveryInfo newUserInfo);

        /// <summary>
        /// Get  Current user info
        /// </summary>
        Task<UserDeliveryInfo> TryGetGetCurrentUserInfoAsync();

        /// <summary>
        /// Get  all Users
        /// </summary>
        Task<UserDeliveryInfo> TryGetByUserIdAsync(string userId);
    }
}