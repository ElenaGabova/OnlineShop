
using System;
using System.Collections.Generic;
using System.Linq;

namespace ViewModels
{
    public class StorageViewModel
    {
        /// <summary>
        /// Id storage
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// User id of storage
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Product Total cost in Storage
        /// </summary>
        public decimal TotalCost
        {
            get
            {
                return Items.Sum(item => item.Product.Сost * item.Amount);
            }
        }

        /// <summary>
        /// Product Total amount in Storage
        /// </summary>
        public int TotalAmount
        {
            get
            {
                return Items.Sum(item => item.Amount);
            }
        }

        /// <summary>
        /// Check if favorite Storage empty
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return Items.Count == 0;
            }
        }

        /// <summary>
        /// Storage elemants
        /// </summary>
        public List<StorageItemViewModel> Items { get; set; }

        public StorageViewModel(string userId) : this(userId, null)
        {
        }

        public StorageViewModel(string userId, ProductViewModel product = null)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            Items = new List<StorageItemViewModel>();

            if (product != null)
                Items.Add(new StorageItemViewModel(product));
        }
    }
}
