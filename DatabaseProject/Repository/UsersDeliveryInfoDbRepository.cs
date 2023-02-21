using Database.Service;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Database.Repository
{
    public class UsersDeliveryInfoDbRepository : IUserDeliveryInfoBase
    {
        private readonly DatabaseContext databaseContext;

        /// <summary>
        /// Init storage collection default
        /// </summary>
        public UsersDeliveryInfoDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        /// <summary>
        /// Get User by id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<UserDeliveryInfoEntity> TryGetByUserIdAsync(string userId)
        {
            return await databaseContext.UserDeliveryInfos.FirstOrDefaultAsync(p => p.Id == userId);
        }

        /// <summary>
        /// Get  Current user info
        /// </summary>
        public async Task<UserDeliveryInfoEntity> TryGetGetCurrentUserInfoAsync()
        {
            return await databaseContext.UserDeliveryInfos.FirstOrDefaultAsync();
        }

        /// <summary>
        /// Add User to User storage
        /// </summary>
        public async Task AddAsync(string userName, string userPhone, string email)
        {
            databaseContext.UserDeliveryInfos.Add(new UserDeliveryInfoEntity(Guid.NewGuid().ToString(), userName, userPhone, email));
            await databaseContext.SaveChangesAsync();
        }

        /// <summary>
        /// Update info about User
        /// </summary>
        /// <param name="curentUserInfo">curent User id</param>
        /// <param name="newUserInfo">new UserInfo</param>
        public async Task<UserDeliveryInfoEntity> UpdateAsync(string curentUserId, UserDeliveryInfoEntity newUserInfo)
        {
            UserDeliveryInfoEntity curentUserInfo = await TryGetByUserIdAsync(curentUserId);

            if (curentUserInfo == null)
                curentUserInfo = new UserDeliveryInfoEntity();

            curentUserInfo.Id = curentUserId;
            curentUserInfo.Name = newUserInfo.Name;
            curentUserInfo.PhoneNumber = newUserInfo.PhoneNumber;
            curentUserInfo.Email = newUserInfo.Email;
            curentUserInfo.Comment = newUserInfo.Comment;
            await databaseContext.SaveChangesAsync();

            return curentUserInfo;
        }
    }
}
