using System;

namespace Domain
{
    /// <summary>
    /// Item in storage object
    /// </summary>
    public class StorageItem
    {
        /// <summary>
        /// Id StorageItem
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Product in Storage
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Storage object
        /// </summary>
        public Storage Storage { get; set; }

        /// <summary>
        /// Count product in Storage
        /// </summary>
        public int Amount { get; set; }
    }
}