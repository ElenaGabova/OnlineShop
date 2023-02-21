using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Database.Service
{
    public interface IProductBase
    {
        /// <summary>
        /// Get  all products
        /// </summary>
        Task<List<ProductEntity>> GetAllProductsAsync();

        /// <summary>
        /// Get product by Id
        /// </summary>
        /// <param name="id">id of Product</param>
        /// <returns>info about products by id</returns>
        Task<ProductEntity> TryGetByIdAsync(int id);

        /// <summary>
        /// Add new product
        /// </summary>
        /// <param name="product"></param>
        Task AddAsync(ProductEntity product);

        /// <summary>
        /// Edit product
        /// </summary>
        /// <param name="product"></param>
        Task EditAsync(ProductEntity product);

        /// <summary>
        /// Remove product
        /// </summary>
        /// <param name="productId"></param>
        Task DeleteAsync(int productId);
    }
}