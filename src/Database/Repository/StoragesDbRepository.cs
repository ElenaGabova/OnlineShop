using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Service;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Database.Repository
{
    public class StoragesDbRepository : IStoragesBase
    {
        private readonly DatabaseContext databaseContext;

        /// <summary>
        /// Init storage collection default
        /// </summary>
        public StoragesDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        /// <summary>
        /// Add Product to Product storage
        /// </summary>
        /// <param name="product"></param>
        public async void Add(string userId, ProductEntity product)
        {
            StorageEntity existingStorage = TryGetByUserIdAsync((userId)).Result;
            ProductEntity existingProduct = databaseContext.Products.FirstOrDefaultAsync(s =>  s.Id == product.Id).Result;

            if (existingStorage != null)
            {
                StorageItemEntity existsingStorageItem = existingStorage.Items.FirstOrDefault(x => x.Product.Id == product.Id);

                if (existsingStorageItem == null)
                    existingStorage.Items.Add(new StorageItemEntity()
                    {
                        Amount = 1,
                        Storage = existingStorage,
                        Product = existingProduct
                    });
                else
                    existsingStorageItem.Amount += 1;
            }
            else
            {
                var newStorage = new StorageEntity
                {
                    UserId = userId
                };

                newStorage.Items =  new List<StorageItemEntity>()
                {
                    new StorageItemEntity() {
                        Id = System.Guid.NewGuid(),
                        Amount = 1,
                        Storage = newStorage,
                        Product = existingProduct
                    }
                };
               await databaseContext.Storages.AddAsync(newStorage).ConfigureAwait(false);
            }

            databaseContext.SaveChanges();
            return;
        }

        /// <summary>
        /// Delete 1 position product from storage
        /// </summary>
        /// <param name="product"></param>
        public async Task DeleteAsync(string userId, ProductEntity product)
        {
            StorageEntity existingStorage = TryGetByUserIdAsync((userId)).Result;
            if (existingStorage != null)
            {
                var existingStorageItem = existingStorage.Items.FirstOrDefault(p => p.Product.Id == product.Id);
                if (existingStorageItem != null)
                {
                    existingStorageItem.Amount -= 1;

                    if (existingStorageItem.Amount == 0)
                        existingStorage.Items.Remove(existingStorageItem);
                }

               await databaseContext.SaveChangesAsync();
            
            }   
        }

        /// <summary>
        ///Remove all positions product from storage
        /// </summary>
        /// <param name="product"></param>
        public async Task RemoveAllPositionsAsync(string userId, ProductEntity product)
        {
            StorageEntity existingStorage = await TryGetByUserIdAsync(userId);
            if (existingStorage != null)
            {
                var existingStorageItem = existingStorage.Items.FirstOrDefault(p => p.Product.Id == product.Id);
                if (existingStorageItem != null)
                    existingStorage.Items.Remove(existingStorageItem);

                await databaseContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Get storage by UserId
        /// </summary>
        public async Task<StorageEntity> TryGetByUserIdAsync(string userId)
        {
            return await databaseContext.Storages.
                                   Include(x=> x.Items).
                                   ThenInclude(x => x.Product).
                                   FirstOrDefaultAsync(p => p.UserId == userId);
        }

        /// <summary>
        /// Delete storage for user
        /// </summary>
        /// <param name="product"></param>
        public async Task DeleteStorageAsync(string userId)
        {
            StorageEntity existingStorage = await TryGetByUserIdAsync(userId);
            if (existingStorage != null)
            {
                databaseContext.StorageItems.RemoveRange(existingStorage.Items);
                databaseContext.Storages.Remove(existingStorage);
                await databaseContext.SaveChangesAsync();
            }
        }
    }
}
