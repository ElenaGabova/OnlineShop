using System.Collections.Generic;
using System.Threading.Tasks;
using Database.Service;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Database.Repository
{
    public class ProductsDbRepository : IProductBase
    {
        private readonly DatabaseContext databaseContext;
        
        /// <summary>
        /// Init product collection default
        /// </summary>
        public ProductsDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        /// <summary>
        /// Get  all products
        /// </summary>
        public async Task<List<ProductEntity>> GetAllProductsAsync()
        {
            var products =  databaseContext.Products;
            return await products.ToListAsync();
        }

        /// <summary>
        /// Get product by Id
        /// </summary>
        /// <param name="id">id of Product</param>
        /// <returns>info about products by id</returns>
        public async Task<ProductEntity> TryGetByIdAsync(int id)
        {
            return await databaseContext.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        /// <summary>
        /// Add new product
        /// </summary>
        /// <param name="product"></param>
        public async Task AddAsync(ProductEntity product)
        {
            await databaseContext.Products.AddAsync(product);
            await databaseContext.SaveChangesAsync();
        }

        /// <summary>
        /// Edit Product
        /// </summary>
        /// <param name="product"></param>
        public async Task EditAsync(ProductEntity product)
        {
            ProductEntity existingProduct = await TryGetByIdAsync(product.Id);

            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Сost = product.Сost;
                existingProduct.Description = product.Description;
                if (product.ImagePath != null)
                 existingProduct.ImagePath   = product.ImagePath;
                await databaseContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Remove product
        /// </summary>
        /// <param name="product"></param>
        public async Task DeleteAsync(int productId)
        {
            ProductEntity existingProduct = await TryGetByIdAsync(productId);
            if (existingProduct != null)
            {
                databaseContext.Products.Remove(existingProduct);
                await databaseContext.SaveChangesAsync();
            }
        }
    }
}
