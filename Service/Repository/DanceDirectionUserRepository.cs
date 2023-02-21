using AutoMapper;
using Database.Service;
using DatabaseProject.Services;
using Domain;
using Entities;
using Microsoft.Extensions.Logging;
using Service;

namespace Service.Repository
{
    public class DanceDirectionUserRepository : IDanceDirectionUserService
    {

        private readonly IDirectionUserBase _danceDirectionUserBase;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public DanceDirectionUserRepository(IDirectionUserBase danceDirectionUserBase, IMapper mapper, ILogger<DanceDirectionRepository> logger)
        {
            _danceDirectionUserBase = danceDirectionUserBase;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Get danceDirections by Id
        /// </summary>
        /// <param name="id">id of danceDirections</param>
        /// <returns>info about danceDirection by id</returns>
        public async Task<DanceDirectionUser> TryGetByIdAsync(Guid id)
        {
            DanceDirectionUser danceDirection = null;
            try
            {
                var danceDirectionEntity = await _danceDirectionUserBase.TryGetByIdAsync(id);
                danceDirection = _mapper.Map<DanceDirectionUser>(danceDirectionEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error danceDirection TryGetById. Error: {ex.Message}");
            }

            return danceDirection;
        }

        /// <summary>
        /// Add new danceDirection
        /// </summary>
        /// <param name="danceDirection"></param>
        public async Task<DanceDirectionUser> AddAsync(DanceDirectionUser danceDirection)
        {
            DanceDirectionUserEntity danceDirectionUser = null;
            try
            {
                danceDirectionUser = await _danceDirectionUserBase.AddAsync(_mapper.Map<DanceDirectionUserEntity>(danceDirection));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error danceDirection Add(productId= {danceDirection.Id}. Error: {ex.Message}");
            }

            return _mapper.Map<DanceDirectionUser>(danceDirectionUser);
        }
    }
}
