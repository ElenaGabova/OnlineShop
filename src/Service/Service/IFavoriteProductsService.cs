using Domain;

namespace Service
{
    public interface IFavoriteProductsService
    {
        /// <summary>
        /// Get  all favorite products
        /// </summary>
        Task<List<Product>> GetAllAsync(string userId);

        /// <summary>
        /// Add Product to favorite
        /// </summary>
        /// <param name="product"></param>
        Task AddAsync(string userId, Product product);

        /// <summary>
        /// Delete Product from favorite
        /// </summary>
        /// <param name="product"></param>
        Task RemoveAsync(string userId, Product product);

        /// <summary>
        /// Clear all favorite of user
        /// </summary>
        /// <param name="userId"></param>
        Task ClearAsync(string userId);
    }
}