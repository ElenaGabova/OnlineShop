using Domain;

namespace Service
{
    public interface IDanceDirectionService
    {
        /// <summary>
        /// Get  all danceDirection
        /// </summary>
        Task<List<DanceDirection>> GetAllDanceDirectionAsync(bool? soloOrDouble = null);

        /// <summary>
        /// Get danceDirection by Id
        /// </summary>
        /// <param name="id">id of danceDirection</param>
        /// <returns>info about danceDirection by id</returns>
        Task<DanceDirection> TryGetByIdAsync(int id);

        /// <summary>
        /// Add new danceDirection
        /// </summary>
        /// <param name="danceDirection"></param>
        Task AddAsync(DanceDirection danceDirection);

        /// <summary>
        /// Edit danceDirection
        /// </summary>
        /// <param name="product"></param>
        Task EditAsync(DanceDirection danceDirection);

        /// <summary>
        /// Remove danceDirection
        /// </summary>
        /// <param name="productId"></param>
        Task DeleteAsync(int productId);
    }
}