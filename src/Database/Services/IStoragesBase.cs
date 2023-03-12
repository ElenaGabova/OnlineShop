using Entities;
using System.Threading.Tasks;

namespace Database.Service
{
    public interface IStoragesBase
    {
        /// <summary>
        /// Add Product to Product storage
        /// </summary>
        /// <param name="product"></param>
        void Add(string userId, ProductEntity product);

        /// <summary>
        /// Delete 1 position product from storage
        /// </summary>
        /// <param name="product"></param>
        Task DeleteAsync(string userId, ProductEntity product);

        /// <summary>
        /// Remove all positions product from storage
        /// </summary>
        /// <param name="product"></param>
        Task RemoveAllPositionsAsync(string userId, ProductEntity product);

        /// <summary>
        /// Get storage by UserId
        /// </summary>
        Task<StorageEntity> TryGetByUserIdAsync(string userId);

        /// <summary>
        /// Delete storage for user
        /// </summary>
        /// <param name="product"></param>
        Task DeleteStorageAsync(string userId);
    }
}