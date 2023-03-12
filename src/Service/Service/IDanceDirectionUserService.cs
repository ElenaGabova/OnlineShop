using Domain;

namespace Service
{
    public interface IDanceDirectionUserService
    {

        /// <summary>
        /// Get danceDirectionUser by Id
        /// </summary>
        /// <param name="id">id of danceDirection</param>
        /// <returns>info about danceDirection by id</returns>
        Task<DanceDirectionUser> TryGetByIdAsync(Guid id);

        /// <summary>
        /// Add new danceDirection
        /// </summary>
        /// <param name="danceDirection"></param>
        Task<DanceDirectionUser> AddAsync(DanceDirectionUser danceDirectionUser);

    }
}