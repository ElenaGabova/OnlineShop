using Entities;
using System.Threading.Tasks;

namespace Database.Service
{
    public interface IUserDeliveryInfoBase
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
        Task<UserDeliveryInfoEntity> UpdateAsync(string curentUserId, UserDeliveryInfoEntity newUserInfo);

        /// <summary>
        /// Get  Current user info
        /// </summary>
        Task<UserDeliveryInfoEntity> TryGetGetCurrentUserInfoAsync();

        /// <summary>
        /// Get  all Users
        /// </summary>
        Task<UserDeliveryInfoEntity> TryGetByUserIdAsync(string userId);
    }
}