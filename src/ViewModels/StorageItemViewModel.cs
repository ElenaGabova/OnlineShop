
using System;
namespace ViewModels
{
    /// <summary>
    /// Item in storage object
    /// </summary>
    public class StorageItemViewModel
    {
        /// <summary>
        /// Id StorageItem
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Product in Storage
        /// </summary>
        public ProductViewModel Product { get; set; }

        /// <summary>
        /// Count product in Storage
        /// </summary>
        public int Amount { get; set; }

        public StorageItemViewModel(ProductViewModel product)
        {
            Id = new Guid();
            Product = product;
            Amount = 1;
        }
    }
}