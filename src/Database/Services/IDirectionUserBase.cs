using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Services
{
    public interface IDirectionUserBase
    {

        /// <summary>
        /// Get danceDirection by Id
        /// </summary>
        /// <param name="id">id of danceDirection</param>
        /// <returns>info about danceDirection by id</returns>
        Task<DanceDirectionUserEntity> TryGetByIdAsync(Guid id);

        /// <summary>
        /// Add new danceDirection
        /// </summary>
        /// <param name="danceDirection"></param>
        Task<DanceDirectionUserEntity> AddAsync(DanceDirectionUserEntity danceDirectionUser);
     
    }
}
