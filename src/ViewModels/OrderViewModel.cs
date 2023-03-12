using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace ViewModels
{
    public class OrderViewModel
    {
        /// <summary>
        /// Order id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Order User
        /// </summary>
        public UserDeliveryInfoViewModel? User { get; set; }

        /// <summary>
        /// Order Storage
        /// </summary>
        public List<StorageItemViewModel>? Items { get; set; }

        /// <summary>
        /// Order status
        /// </summary>
        public OrderStatusViewModel Status{ get; set; }

        /// <summary>
        /// Order date and time
        /// </summary>
        public DateTime CreatedDateTime { get; set; }

        /// <summary>
        /// Order cost
        /// </summary>
        public decimal Cost { get; set; }

        public OrderViewModel() { }

        /// <summary>
        /// Constructor for deserialize from json
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        /// <param name="storageItemsCollection"></param>
        [JsonConstructorAttribute]
        public OrderViewModel(Guid id, UserDeliveryInfoViewModel userDeliveryInfo, List<StorageItemViewModel> items, DateTime createdDateTime, OrderStatusViewModel status, decimal cost)
        {
            Id = id;
            User = userDeliveryInfo;
            Items = items;
            Cost = cost;
            CreatedDateTime = createdDateTime;
            Status = status;
        }

    }
}
