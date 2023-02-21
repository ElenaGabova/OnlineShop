using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Domain
{
    public class Storage
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
        public List<StorageItem> Items { get; set; }

        public Storage()
        {   
            Items = new List<StorageItem>();
        }
    }
}
