using Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Database.Service
{
    public interface IOrdersBase
    {
        /// <summary>
        /// Add order
        /// </summary>
        /// <param name="user"></param>
        /// <param name="storage"></param>
        /// <returns></returns>
        Task<OrderEntity> AddAsync(UserDeliveryInfoEntity user, StorageEntity storage);

        /// <summary>
        /// Try get ordr by id
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<OrderEntity> TryGetByIdAsync(Guid orderId);

        /// <summary>
        /// Get all orders
        /// </summary>
        /// <returns></returns>
        Task<List<OrderEntity>> GetAllOrdersAsync();

        /// <summary>
        /// Change order status by orderId
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="orderStatus"></param>
        Task UpdateStatusAsync(Guid orderId, OrderStatusEntity orderStatus);
    }
}