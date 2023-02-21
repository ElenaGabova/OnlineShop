using AutoMapper;
using Database.Service;
using Domain;
using Entities;
using Microsoft.Extensions.Logging;
using Service;

namespace Service.Repository;

public class FavoriteProductsRepository : IFavoriteProductsService
{
    private readonly IFavoriteProductsBase _favoriteProductBase;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public FavoriteProductsRepository(IFavoriteProductsBase favoriteProductBase, IMapper mapper, ILogger<FavoriteProductsRepository> logger)
    {
        _favoriteProductBase = favoriteProductBase;
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    /// Get  all favorite products of user
    /// </summary>
    public async Task<List<Product>> GetAllAsync(string userId)
    {
        List<Product> products = new List<Product>();
        try
        {
            List<ProductEntity> productEntities = await _favoriteProductBase.GetAllAsync(userId);
            products = _mapper.Map<List<Product>>(productEntities);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error FavoriteProduct GetAll. Error: {ex.Message}");
        }

        return products;
    }

    /// <summary>
    /// Clear user favorite
    /// </summary>
    /// <param name="userId"></param>
    public async Task ClearAsync(string userId)
    {
        try
        {
            await _favoriteProductBase.ClearAsync(userId);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error FavoriteProduct Clear. Error: {ex.Message}");
        }
    }

    /// <summary>
    /// Add Product to favorite
    /// </summary>
    /// <param name="product"></param>
    public async Task AddAsync(string userId, Product product)
    {
        try
        {
            await _favoriteProductBase.AddAsync(userId, _mapper.Map<ProductEntity>(product));
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error FavoriteProduct AddAsync(userId = {userId}, productId= {product.Id}. Error: {ex.Message}");
        }
    }

    /// <summary>
    /// Delete Product from favorite
    /// </summary>
    /// <param name="product"></param>
    public async Task RemoveAsync(string userId, Product product)
    {
        try
        {
            await _favoriteProductBase.RemoveAsync(userId, _mapper.Map<ProductEntity>(product));
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error FavoriteProduct Remove(userId = {userId}, productId= {product.Id}. Error: {ex.Message}");
        }
    }
}
