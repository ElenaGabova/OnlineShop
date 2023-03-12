using System;
using System.Text.Json.Serialization;

namespace Entities
{
    /// <summary>
    /// Item in storage object
    /// </summary>
    public class StorageItemEntity
    {
        /// <summary>
        /// Id StorageItem
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Product in Storage
        /// </summary>
        public ProductEntity Product { get; set; }

        [JsonIgnore]
        /// <summary>
        /// Storage object
        /// </summary>
        public StorageEntity Storage { get; set; }

        /// <summary>
        /// Count product in Storage
        /// </summary>
        public int Amount { get; set; }
    }
}