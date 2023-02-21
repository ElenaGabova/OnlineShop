using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Database.Service
{
    public interface IDirectionBase
    {

        /// <summary>
        /// Get  all danceDirection
        /// </summary>
        Task<List<DanceDirectionEntity>> GetAllDanceDirectionAsync(bool? soloOrDouble = null);

        /// <summary>
        /// Get danceDirection by Id
        /// </summary>
        /// <param name="id">id of danceDirection</param>
        /// <returns>info about danceDirection by id</returns>
        Task<DanceDirectionEntity> TryGetByIdAsync(int id);

        /// <summary>
        /// Add new danceDirection
        /// </summary>
        /// <param name="danceDirection"></param>
        Task AddAsync(DanceDirectionEntity danceDirection);

        /// <summary>
        /// Edit danceDirection
        /// </summary>
        /// <param name="product"></param>
        Task EditAsync(DanceDirectionEntity danceDirection);

        /// <summary>
        /// Remove danceDirection
        /// </summary>
        /// <param name="productId"></param>
        Task DeleteAsync(int productId);
    }
}