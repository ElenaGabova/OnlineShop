using Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Database.Service
{
    public interface IDanceDirectionRegistrationBase
    {
        /// <summary>
        /// Add DanceDirectionRegistration
        /// </summary>
        /// <param name="user"></param>
        /// <param name="storage"></param>
        /// <returns></returns>
        Task AddAsync(DanceDirectionRegistrationEntity danceDirectionRegistration);

        /// <summary>
        /// Try get DanceDirectionRegistration by id
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<DanceDirectionRegistrationEntity> TryGetByIdAsync(Guid orderId);

        /// <summary>
        /// Get all orders
        /// </summary>
        /// <returns></returns>
        Task<List<DanceDirectionRegistrationEntity>> GetAll();

        /// <summary>
        /// Change order status by orderId
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="orderStatus"></param>
        Task UpdateAsync(Guid danseDirectionRegistrationId, bool needToContact);
    }
}