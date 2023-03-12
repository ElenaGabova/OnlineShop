using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Service;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Database.Repository
{
    public class DanceDirectionDbRepository : IDirectionBase
    {
        private readonly DatabaseContext databaseContext;
        
        /// <summary>
        /// Init product collection default
        /// </summary>
        public DanceDirectionDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        /// <summary>
        /// Get  all danceDirections
        /// </summary>
        public async Task<List<DanceDirectionEntity>> GetAllDanceDirectionAsync(bool? soloOrDouble = null)
        {
            List<DanceDirectionEntity> danceDirections;
            if (soloOrDouble == null)
                 danceDirections = await databaseContext.DanceDirections.ToListAsync();
            else
                danceDirections = await databaseContext.DanceDirections.Where(d => d.SoloDoubleSign == soloOrDouble.Value).ToListAsync();

            return danceDirections;
        }

        /// <summary>
        /// Get danceDirections by Id
        /// </summary>
        /// <param name="id">id of danceDirections</param>
        /// <returns>info about danceDirections by id</returns>
        public async Task<DanceDirectionEntity> TryGetByIdAsync(int id)
        {
            return await databaseContext.DanceDirections.FirstOrDefaultAsync(p => p.Id == id);
        }

        /// <summary>
        /// Add new danceDirection
        /// </summary>
        /// <param name="product"></param>
        public async Task AddAsync(DanceDirectionEntity danceDirection)
        {
            await databaseContext.DanceDirections.AddAsync(danceDirection);
            await databaseContext.SaveChangesAsync();
        }

        /// <summary>
        /// Edit danceDirection
        /// </summary>
        /// <param name="product"></param>
        public async Task EditAsync(DanceDirectionEntity danceDirection)
        {
            DanceDirectionEntity existingDanceDirection = await TryGetByIdAsync(danceDirection.Id);

            if (existingDanceDirection != null)
            {
                existingDanceDirection.Name = danceDirection.Name;
                existingDanceDirection.Description = danceDirection.Description;
                existingDanceDirection.MainPhoto = danceDirection.MainPhoto;
                existingDanceDirection.OtherPhotos   = danceDirection.OtherPhotos;
                existingDanceDirection.VideoLinks = danceDirection.VideoLinks;
                existingDanceDirection.SoloDoubleSign = danceDirection.SoloDoubleSign;
                await databaseContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Remove danceDirection
        /// </summary>
        /// <param name="product"></param>
        public async Task DeleteAsync(int danceDirectionId)
        {
            DanceDirectionEntity existingDanceDirection = await TryGetByIdAsync(danceDirectionId);
            if (existingDanceDirection != null)
            {
                databaseContext.DanceDirections.Remove(existingDanceDirection);
                await databaseContext.SaveChangesAsync();
            }
        }
    }
}
