using System.Text.Json.Serialization;

namespace Entities
{
    public class ProductEntity
    {
        /// <summary>
        /// Product Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Product Name
        /// </summary>
        /// 
        public string Name { get; set; }

        /// <summary>
        /// Product cost
        /// </summary>
        /// 
        public decimal Сost { get; set; }

        /// <summary>
        /// Product description
        /// </summary>
        /// 
        public string Description { get; set; }

        /// <summary>
        /// Path of image
        /// </summary>
        /// 
        public string? ImagePath { get; set; }

        [JsonIgnore]
        /// <summary>
        /// Storage items list
        /// </summary>
        public List<StorageItemEntity> StorageItems { get; set; }

        public ProductEntity()
        {  

        }
    }
}
