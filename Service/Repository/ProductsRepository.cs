using AutoMapper;
using Database.Service;
using Domain;
using Entities;
using Microsoft.Extensions.Logging;
using Service;

namespace Service.Repository
{
    public class ProductsRepository : IProductsService
    {

        private readonly IProductBase _productBase;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public ProductsRepository(IProductBase productBase, IMapper mapper, ILogger<ProductsRepository> logger)
        {
            _productBase = productBase;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Get  all products
        /// </summary>
        public async Task<List<Product>> GetAllProductsAsync()
        {
            List<Product> products = new List<Product>();
            try
            {
                List<ProductEntity> productEntities = await _productBase.GetAllProductsAsync();
                products = _mapper.Map<List<Product>>(productEntities);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error product GetAll. Error: {ex.Message}");
            }

            return products;
        }

        /// <summary>
        /// Get product by Id
        /// </summary>
        /// <param name="id">id of Product</param>
        /// <returns>info about products by id</returns>
        public async Task<Product> TryGetByIdAsync(int id)
        {
            Product product = null;
            try
            {
                var productEntity = await _productBase.TryGetByIdAsync(id);
                product = _mapper.Map<Product>(productEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error product TryGetById. Error: {ex.Message}");
            }

            return product;
        }

        /// <summary>
        /// Add new product
        /// </summary>
        /// <param name="product"></param>
        public async Task AddAsync(Product product)
        {
            try
            {
                await _productBase.AddAsync(_mapper.Map<ProductEntity>(product));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error product Add(productId= {product.Id}. Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Edit Product
        /// </summary>
        /// <param name="product"></param>
        public async Task EditAsync(Product product)
        {
            try
            {
                await _productBase.EditAsync(_mapper.Map<ProductEntity>(product));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error product Edit(productId= {product.Id}. Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Remove product
        /// </summary>
        /// <param name="product"></param>
        public async Task DeleteAsync(int productId)
        {
            try
            {
                await _productBase.DeleteAsync(productId);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error product Delete(productId= {productId}. Error: {ex.Message}");
            }
        }
    }
}
