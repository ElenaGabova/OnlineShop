using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;
using Database.Service;

namespace Database.Repository;

public class FavoriteProductsDbRepository : IFavoriteProductsBase
{
  
    private readonly DatabaseContext databaseContext;

    /// <summary>
    /// Init product collection default
    /// </summary>
    public FavoriteProductsDbRepository(DatabaseContext databaseContext)
    {
        this.databaseContext = databaseContext;
    }

    /// <summary>
    /// Get  all favorite products of user
    /// </summary>
    public async Task<List<ProductEntity>> GetAllAsync(string userId)
    {
        return await  databaseContext.FavoriteProducts.
                                Where(x => x.UserId == userId).
                                Include(x => x.Product).
                                Select(x => x.Product).
                                ToListAsync();
    }

    /// <summary>
    /// Clear user favorite
    /// </summary>
    /// <param name="userId"></param>
    public async Task ClearAsync(string userId)
    {
        List<FavoriteProductEntity> reomoveProductsList = await databaseContext.FavoriteProducts.Where(s => s.UserId == userId).ToListAsync();
        databaseContext.FavoriteProducts.RemoveRange(reomoveProductsList);
        await databaseContext.SaveChangesAsync();
    }

    /// <summary>
    /// Add Product to favorite
    /// </summary>
    /// <param name="product"></param>
    public async Task AddAsync(string userId, ProductEntity product)
    {
        FavoriteProductEntity existingProductInFavorite = await databaseContext.FavoriteProducts.FirstOrDefaultAsync(s => s.UserId == userId && s.Product.Id == product.Id);
        ProductEntity productEntity = await databaseContext.Products.FirstOrDefaultAsync(s => s.Id == product.Id);
        if (existingProductInFavorite == null)
        {
            await databaseContext.FavoriteProducts.AddAsync(new FavoriteProductEntity() {
                UserId = userId,
                Product = productEntity
            });

            await databaseContext.SaveChangesAsync();
        }
    }

    /// <summary>
    /// Delete Product from favorite
    /// </summary>
    /// <param name="product"></param>
    public async Task RemoveAsync(string userId, ProductEntity product)
    {
        FavoriteProductEntity reomoveProduct = await databaseContext.FavoriteProducts.FirstOrDefaultAsync(s => s.UserId == userId && s.Product == product);
        databaseContext.FavoriteProducts.Remove(reomoveProduct);
        await databaseContext.SaveChangesAsync();
    }
}
