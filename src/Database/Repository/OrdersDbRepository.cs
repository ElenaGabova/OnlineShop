using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;
using Database.Service;
using System.Linq;

namespace Database.Repository
{
    public class OrdersDbRepository : IOrdersBase
    {
        private readonly DatabaseContext databaseContext;

        /// <summary>
        /// Init product collection default
        /// </summary>
        public OrdersDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        /// <summary>
        /// CheckoutOrder
        /// </summary>
        /// <param name="product"></param>
        public async Task<OrderEntity> AddAsync(UserDeliveryInfoEntity user, StorageEntity storage)
        {
            OrderEntity  newOrder = new OrderEntity();
            StorageEntity storageEntity = await databaseContext.Storages.
                                                Include(x => x.Items).
                                                ThenInclude(x => x.Product).
                                                FirstOrDefaultAsync(s => s.Id == storage.Id);     

            if (storageEntity == null)
                storageEntity = storage;

            List<StorageItemEntity> storageItemEntity = await databaseContext.StorageItems.Select(s=>s).Where(s => s.Storage.Id == storage.Id).ToListAsync();
            UserDeliveryInfoEntity userEntity = await databaseContext.UserDeliveryInfos.FirstOrDefaultAsync(s => s.Id == user.Id) ?? user;
            newOrder.User = userEntity;
            newOrder.Cost = storageItemEntity.Sum(item => item.Product.Сost * item.Amount);
            newOrder.User.Storage = storageEntity;
            newOrder.User.Storage.Items = storageItemEntity;

            if (databaseContext.Orders.AddAsync(newOrder).IsCompleted)
                databaseContext.SaveChanges();
           return newOrder;
        }

        /// <summary>
        /// Get order by orderId
        /// </summary>
        public async Task<OrderEntity> TryGetByIdAsync(Guid orderId)
        {
            return await databaseContext.Orders.Include(u => u.User).FirstOrDefaultAsync(p => p.Id == orderId);
        }

        /// <summary>
        /// Get all orders
        /// </summary>
        /// <returns></returns>
        public async Task<List<OrderEntity>> GetAllOrdersAsync()
        {
            return await databaseContext.Orders.Include(u => u.User).OrderByDescending(o => o.CreatedDateTime).ToListAsync();
        }

        /// <summary>
        /// Change order status in repository
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="orderStatus"></param>
        /// <exception cref="NotImplementedException"></exception>
        public async Task UpdateStatusAsync(Guid orderId, OrderStatusEntity orderStatus)
        {
            OrderEntity existingOrder = await TryGetByIdAsync(orderId);
            if (existingOrder != null)
            {
                existingOrder.Status = orderStatus;
                databaseContext.Update(existingOrder);
                await databaseContext.SaveChangesAsync();
            }
        }
    }
}
