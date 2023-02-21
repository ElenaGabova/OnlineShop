using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Service;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Database.Repository
{
    public class DanceDirectionRegistrationDbRepository : IDanceDirectionRegistrationBase
    {
        private readonly DatabaseContext databaseContext;
        
        /// <summary>
        /// Init product collection default
        /// </summary>
        public DanceDirectionRegistrationDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        /// <summary>
        /// Get  all DanceDirectionRegistrations
        /// </summary>
        public async Task<List<DanceDirectionRegistrationEntity>> GetAll()
        {
            return  await databaseContext.DanceDirectionRegistrations.Include(u => u.DanceDirectionUserEntity).Include(u => u.DanceDirectionEntity).ToListAsync();
        }

        /// <summary>
        /// Get DanceDirectionRegistrations by Id
        /// </summary>
        /// <param name="id">id of DanceDirectionRegistrations</param>
        /// <returns>info about DanceDirectionRegistrations by id</returns>
        public async Task<DanceDirectionRegistrationEntity> TryGetByIdAsync(Guid id)
        {
            return await databaseContext.DanceDirectionRegistrations.Include(u => u.DanceDirectionUserEntity).Include(u => u.DanceDirectionEntity).FirstOrDefaultAsync(p => p.Id == id);
        }

        /// <summary>
        /// Add new danceDirection
        /// </summary>
        /// <param name="product"></param>
        public async Task AddAsync(DanceDirectionRegistrationEntity danceDirectionRegistration)
        {
            danceDirectionRegistration.DanceDirectionEntity =  databaseContext.DanceDirections.FirstOrDefault(d => d.Id == danceDirectionRegistration.DanceDirectionEntity.Id);
            danceDirectionRegistration.DanceDirectionUserEntity =  databaseContext.DanceDirectionUsers.FirstOrDefault(d => d.Id == danceDirectionRegistration.DanceDirectionUserEntity.Id);

            await databaseContext.DanceDirectionRegistrations.AddAsync(danceDirectionRegistration);
            await databaseContext.SaveChangesAsync();
        }

        /// <summary>
        /// Edit danceDirection
        /// </summary>
        /// <param name="product"></param>
        public async Task UpdateAsync(Guid danseDirectionRegistrationId, bool needToContact)
        {
            DanceDirectionRegistrationEntity existingDanceRegistrationDirection = await TryGetByIdAsync(danseDirectionRegistrationId);

            if (existingDanceRegistrationDirection != null)
            {
                existingDanceRegistrationDirection.NeedToCall = needToContact;
                await databaseContext.SaveChangesAsync();
            }
        }

  
    }
}
