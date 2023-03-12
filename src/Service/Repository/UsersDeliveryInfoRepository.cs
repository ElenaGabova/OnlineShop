using AutoMapper;
using Database.Service;
using Domain;
using Entities;
using Microsoft.Extensions.Logging;
using Service;

namespace Service.Repository
{
    public class UsersDeliveryInfoRepository : IUserDeliveryInfoService
    {
        private readonly IUserDeliveryInfoBase _usersDeliveryInfoBase;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;


        public UsersDeliveryInfoRepository(IUserDeliveryInfoBase usersDeliveryInfoBase, IMapper mapper, ILogger<UsersDeliveryInfoRepository> logger)
        {
            _usersDeliveryInfoBase = usersDeliveryInfoBase;
            _mapper = mapper;
            _logger = logger;
        }


        /// <summary>
        /// Get User by id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<UserDeliveryInfo> TryGetByUserIdAsync(string userId)
        {
            UserDeliveryInfo userDeliveryInfo = null;
            try
            {
                UserDeliveryInfoEntity userDeliveryInfoEntity = await _usersDeliveryInfoBase.TryGetByUserIdAsync(userId);
                userDeliveryInfo = _mapper.Map<UserDeliveryInfo>(userDeliveryInfoEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error UserDeliveryInfo TryGetByUserId(UserId ={userId}). Error: {ex.Message}");
            }

            return userDeliveryInfo;
        }

        /// <summary>
        /// Get  Current user info
        /// </summary>
        public async Task<UserDeliveryInfo> TryGetGetCurrentUserInfoAsync()
        {
            UserDeliveryInfo userDeliveryInfo = null;
            try
            {
                UserDeliveryInfoEntity userDeliveryInfoEntity = await _usersDeliveryInfoBase.TryGetGetCurrentUserInfoAsync();
                userDeliveryInfo = _mapper.Map<UserDeliveryInfo>(userDeliveryInfoEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error UserDeliveryInfo TryGetGetCurrentUserInfo. Error: {ex.Message}");
            }

            return userDeliveryInfo;
        }

        /// <summary>
        /// Add User to User storage
        /// </summary>
        public async Task AddAsync(string userName, string userPhone, string email)
        {
            try
            {
                await _usersDeliveryInfoBase.AddAsync(userName, userPhone, email);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error userDeliveryInfo AddAsync(userName = {userName}, userPhone= {userPhone}, useremail= {email}. Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Update info about User
        /// </summary>
        /// <param name="curentUserInfo">curent User id</param>
        /// <param name="newUserInfo">new UserInfo</param>
        public async Task<UserDeliveryInfo> UpdateAsync(string curentUserId, UserDeliveryInfo newUserInfo)
        {
            UserDeliveryInfo userDeliveryInfo = null;
            try
            {
                UserDeliveryInfoEntity userDeliveryInfoEntity = await _usersDeliveryInfoBase.UpdateAsync(curentUserId,
                                                                                                         _mapper.Map<UserDeliveryInfoEntity>(newUserInfo));
                userDeliveryInfo = _mapper.Map<UserDeliveryInfo>(userDeliveryInfoEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error UserDeliveryInfo Update. Error(UserId ={curentUserId}). Error: {ex.Message}");
            }

            return userDeliveryInfo;
        }
    }
}
