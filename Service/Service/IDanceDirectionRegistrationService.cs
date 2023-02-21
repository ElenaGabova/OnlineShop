using Domain;
using Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Database.Service
{
    public interface IDanceDirectionRegistrationService
    {
        /// <summary>
        /// Add DanceDirectionRegistration
        /// </summary>
        /// <param name="user"></param>
        /// <param name="storage"></param>
        /// <returns></returns>
        Task AddAsync(DanceDirectionRegistration danceDirectionRegistration);

        /// <summary>
        /// Try get DanceDirectionRegistration by id
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<DanceDirectionRegistration> TryGetByIdAsync(Guid orderId);

        /// <summary>
        /// Get all orders
        /// </summary>
        /// <returns></returns>
        Task<List<DanceDirectionRegistration>> GetAll();

        /// <summary>
        /// Change order status by orderId
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="orderStatus"></param>
        Task UpdateAsync(Guid danseDirectionRegistrationId, bool needToContact);
    }
}