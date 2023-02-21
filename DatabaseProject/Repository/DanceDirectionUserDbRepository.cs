using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Service;
using DatabaseProject.Services;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Database.Repository
{
    public class DanceDirectionUserDbRepository : IDirectionUserBase
    {
        private readonly DatabaseContext databaseContext;
        
        /// <summary>
        /// Init product collection default
        /// </summary>
        public DanceDirectionUserDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }


        /// <summary>
        /// Get danceDirections by Id
        /// </summary>
        /// <param name="id">id of danceDirections</param>
        /// <returns>info about danceDirections by id</returns>
        public async Task<DanceDirectionUserEntity> TryGetByIdAsync(Guid id)
        {
            return await databaseContext.DanceDirectionUsers.FirstOrDefaultAsync(p => p.Id == id);
        }

        /// <summary>
        /// Add new danceDirection
        /// </summary>
        /// <param name="product"></param>
        public async  Task<DanceDirectionUserEntity> AddAsync(DanceDirectionUserEntity danceDirection)
        {
            await databaseContext.DanceDirectionUsers.AddAsync(danceDirection);
            await databaseContext.SaveChangesAsync();
            return await databaseContext.DanceDirectionUsers.FirstOrDefaultAsync(d => d.Id == danceDirection.Id);
        }
    }
}
