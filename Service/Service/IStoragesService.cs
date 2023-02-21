using Domain;

namespace Service
{
    public interface IStoragesService
    {
        /// <summary>
        /// Add Product to Product storage, and save as json
        /// </summary>
        /// <param name="product"></param>
        Task AddAsync(string userId, Product product);

        /// <summary>
        /// Delete 1 position product from storage, and save as json
        /// </summary>
        /// <param name="product"></param>
        Task DeleteAsync(string userId, Product product);

        /// <summary>
        /// Remove all positions product from storage, and save as json
        /// </summary>
        /// <param name="product"></param>
        Task RemoveAllPositionsAsync(string userId, Product product);

        /// <summary>
        /// Get storage by UserId
        /// </summary>
        Task<Storage> TryGetByUserIdAsync(string userId);

        /// <summary>
        /// Delete storage for user
        /// </summary>
        /// <param name="product"></param>
        Task DeleteStorageAsync(string userId);
    }
}