using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Order
    {

        /// <summary>
        /// Order id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Order User
        /// </summary>
        public UserDeliveryInfo User { get; set; }
        /// <summary>
        /// Order Storage
        /// </summary>
        public List<StorageItem> Items { get; set; }

        /// <summary>
        /// Order status
        /// </summary>
        public OrderStatus Status { get; set; }

        /// <summary>
        /// Order date and time
        /// </summary>
        public DateTime CreatedDateTime { get; set; }

        /// <summary>
        /// Order cost
        /// </summary>
        public decimal Cost { get; set; }

        public Order()
        {
            Status = OrderStatus.Create;
            CreatedDateTime = DateTime.Now;
        }

        public Order(UserDeliveryInfo user, List<StorageItem> items) : this()
        {
            Id = Guid.NewGuid();
            User = user;
            Items = items;
            Cost = Items.Sum(item => item.Product.Сost * item.Amount);
        }
    }
}
