using Domain;

namespace Service
{
    public interface IOrdersService
    {
        /// <summary>
        /// Add order
        /// </summary>
        /// <param name="user"></param>
        /// <param name="storage"></param>
        /// <returns></returns>
        Task<Order> AddAsync(UserDeliveryInfo user, Storage storage);

        /// <summary>
        /// Try get ordr by id
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<Order> TryGetByIdAsync(Guid orderId);

        /// <summary>
        /// Get all orders
        /// </summary>
        /// <returns></returns>
        Task<List<Order>> GetAllOrdersAsync();

        /// <summary>
        /// Change order status by orderId
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="orderStatus"></param>
        Task UpdateStatusAsync(Guid orderId, OrderStatus orderStatus);
    }
}