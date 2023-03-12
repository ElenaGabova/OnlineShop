using System;
using System.Collections.Generic;
using System.Linq;

namespace Entities
{
    public class OrderEntity
    {

        /// <summary>
        /// Order id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Order User
        /// </summary>
        public UserDeliveryInfoEntity User { get; set; }
        /// <summary>
        /// Order Storage
        /// </summary>
        public List<StorageItemEntity> Items { get; set; }

        /// <summary>
        /// Order status
        /// </summary>
        public OrderStatusEntity Status { get; set; }

        /// <summary>
        /// Order date and time
        /// </summary>
        public DateTime CreatedDateTime { get; set; }

        /// <summary>
        /// Order cost
        /// </summary>
        public decimal Cost { get; set; }

        public OrderEntity()
        {
            Status = OrderStatusEntity.Create;
            CreatedDateTime = DateTime.Now;
        }

    }
}
