using AutoMapper;
using Database.Service;
using Domain;
using Entities;
using Microsoft.Extensions.Logging;
using Service;

namespace Service.Repository
{
    public class StoragesRepository : IStoragesService
    {
        private readonly IStoragesBase _storageBase;
        private readonly IProductBase _productBase;

        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public StoragesRepository(IStoragesBase storageBase, IProductBase productBase, IMapper mapper, ILogger<StoragesRepository> logger)
        {
            _storageBase = storageBase;
            _productBase = productBase;
             _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Add Product to Product storage
        /// </summary>
        /// <param name="product"></param>
        public async Task AddAsync(string userId, Product product)
        {
            try
            {
                _storageBase.Add(userId, _mapper.Map<ProductEntity>(product));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error Storage Add(userId = {userId}, productId= {product.Id}. Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Delete 1 position product from storage
        /// </summary>
        /// <param name="product"></param>
        public async Task DeleteAsync(string userId, Product product)
        {
            try
            {
                await _storageBase.DeleteAsync(userId, _mapper.Map<ProductEntity>(product));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error Storage Delete(userId = {userId}, productId= {product.Id}. Error: {ex.Message}");
            }
        }

        /// <summary>
        ///Remove all positions product from storage
        /// </summary>
        /// <param name="product"></param>
        public async Task RemoveAllPositionsAsync(string userId, Product product)
        {
            try
            {
                await _storageBase.RemoveAllPositionsAsync(userId, _mapper.Map<ProductEntity>(product));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error Storage RemoveAllPositionsAsync(userId = {userId}, productId= {product.Id}. Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Get storage by UserId
        /// </summary>
        public async Task<Storage> TryGetByUserIdAsync(string userId)
        {
            Storage storage = null;
            try
            {
                StorageEntity storageEntity = await _storageBase.TryGetByUserIdAsync(userId);
                storage = _mapper.Map<Storage>(storageEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error storage TryGetById (userId = {userId}). Error: {ex.Message}");
            }

            return storage;
        }

        /// <summary>
        /// Delete storage for user
        /// </summary>
        /// <param name="product"></param>
        public async Task DeleteStorageAsync(string userId)
        {
            try
            {
                await _storageBase.DeleteStorageAsync(userId);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error storage delete (userId = {userId}). Error: {ex.Message}");
            }
        }
    }
}
