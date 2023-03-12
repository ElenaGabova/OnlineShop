using Entities;
using Database.Service;
using Service;
using AutoMapper;
using Domain;
using Microsoft.Extensions.Logging;

namespace Service.Repository
{
    public class OrdersRepository : IOrdersService
    {

        private readonly IOrdersBase _ordersBase;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public OrdersRepository(IOrdersBase ordersBase, IMapper mapper, ILogger<OrdersRepository> logger)
        {
            _ordersBase = ordersBase;
            _mapper = mapper;
            _logger = logger;
        }


        /// <summary>
        /// CheckoutOrder
        /// </summary>
        /// <param name="product"></param>
        public async Task<Order> AddAsync(UserDeliveryInfo user, Storage storage)
        {
            Order order = null;

            try
            {
                   var orderEntity = await _ordersBase.AddAsync(_mapper.Map<UserDeliveryInfoEntity>(user),
                _mapper.Map<StorageEntity>(storage));
                order = _mapper.Map<Order>(orderEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in adding Order into database. Error: {ex.Message}");
            }

            return order;

        }

        /// <summary>
        /// Get order by orderId
        /// </summary>
        public async Task<Order> TryGetByIdAsync(Guid orderId)
        {
            Order order = null;
            try
            {
                var orderEntity = await _ordersBase.TryGetByIdAsync(orderId);
                order = _mapper.Map<Order>(orderEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in order TryGetById({orderId}). Error: {ex.Message}");
            }

            return order;
        }

        /// <summary>
        /// Get all orders
        /// </summary>
        /// <returns></returns>
        public async Task<List<Order>> GetAllOrdersAsync()
        {
            List<Order> orders = new List<Order>();
            try
            {
                List<OrderEntity> ordersEntity = await _ordersBase.GetAllOrdersAsync();
                orders = _mapper.Map<List<Order>>(ordersEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in  GetAllOrders. Error: {ex.Message}");
            }

            return orders;
        }

        /// <summary>
        /// Change order status in repository
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="orderStatus"></param>
        /// <exception cref="NotImplementedException"></exception>
        public async Task UpdateStatusAsync(Guid orderId, OrderStatus orderStatus)
        {
            try
            {
                await _ordersBase.UpdateStatusAsync(orderId, _mapper.Map<OrderStatusEntity>(orderStatus));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in order UpdateStatus({orderId}, {orderStatus.ToString()}). Error: {ex.Message}");
            }
        }
    }
}
