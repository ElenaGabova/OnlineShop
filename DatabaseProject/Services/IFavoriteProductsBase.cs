using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Database.Service
{
    public interface IFavoriteProductsBase
    {
        /// <summary>
        /// Get  all favorite products
        /// </summary>
        Task<List<ProductEntity>> GetAllAsync(string userId);

        /// <summary>
        /// Add Product to favorite
        /// </summary>
        /// <param name="product"></param>
        Task AddAsync(string userId, ProductEntity product);

        /// <summary>
        /// Delete Product from favorite
        /// </summary>
        /// <param name="product"></param>
        Task RemoveAsync(string userId, ProductEntity product);

        /// <summary>
        /// Clear all favorite of user
        /// </summary>
        /// <param name="userId"></param>
        Task ClearAsync(string userId);
    }
}