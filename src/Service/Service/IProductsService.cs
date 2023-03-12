using Domain;

namespace Service
{
    public interface IProductsService
    {
        /// <summary>
        /// Get  all products
        /// </summary>
        Task<List<Product>> GetAllProductsAsync();

        /// <summary>
        /// Get product by Id
        /// </summary>
        /// <param name="id">id of Product</param>
        /// <returns>info about products by id</returns>
        Task<Product> TryGetByIdAsync(int id);

        /// <summary>
        /// Add new product
        /// </summary>
        /// <param name="product"></param>
        Task AddAsync(Product product);

        /// <summary>
        /// Edit product
        /// </summary>
        /// <param name="product"></param>
        Task EditAsync(Product product);

        /// <summary>
        /// Remove product
        /// </summary>
        /// <param name="productId"></param>
        Task DeleteAsync(int productId);
    }
}