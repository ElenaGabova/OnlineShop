using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Entities
{
    public class StorageEntity
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
        /// Storage elemants
        /// </summary>
        public List<StorageItemEntity> Items { get; set; }

        public StorageEntity()
        {   
            Items = new List<StorageItemEntity>();
        }
    }
}
