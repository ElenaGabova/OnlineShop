using AutoMapper;
using Database.Service;
using Domain;
using Entities;
using Microsoft.Extensions.Logging;
using Service;

namespace Service.Repository
{
    public class DanceDirectionRepository : IDanceDirectionService
    {

        private readonly IDirectionBase _danceDirectionBase;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public DanceDirectionRepository(IDirectionBase danceDirectionBase, IMapper mapper, ILogger<DanceDirectionRepository> logger)
        {
            _danceDirectionBase = danceDirectionBase;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Get  all danceDirections
        /// </summary>
        public async Task<List<DanceDirection>> GetAllDanceDirectionAsync(bool? soloOrDouble = null)
        {
            List<DanceDirection> danceDirections = new List<DanceDirection>();
            try
            {
                List<DanceDirectionEntity> danceDirectionEntities = await _danceDirectionBase.GetAllDanceDirectionAsync(soloOrDouble);
                danceDirections = _mapper.Map<List<DanceDirection>>(danceDirectionEntities);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error danceDirection GetAll. Error: {ex.Message}");
            }

            return danceDirections;
        }

        /// <summary>
        /// Get danceDirections by Id
        /// </summary>
        /// <param name="id">id of danceDirections</param>
        /// <returns>info about danceDirection by id</returns>
        public async Task<DanceDirection> TryGetByIdAsync(int id)
        {
            DanceDirection danceDirection = null;
            try
            {
                var danceDirectionEntity = await _danceDirectionBase.TryGetByIdAsync(id);
                danceDirection = _mapper.Map<DanceDirection>(danceDirectionEntity);
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
        public async Task AddAsync(DanceDirection danceDirection)
        {
            try
            {
                await _danceDirectionBase.AddAsync(_mapper.Map<DanceDirectionEntity>(danceDirection));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error danceDirection Add(productId= {danceDirection.Id}. Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Edit danceDirection
        /// </summary>
        /// <param name="danceDirection"></param>
        public async Task EditAsync(DanceDirection danceDirection)
        {
            try
            {
                await _danceDirectionBase.EditAsync(_mapper.Map<DanceDirectionEntity>(danceDirection));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error danceDirection Edit(danceDirectionId= {danceDirection.Id}. Error: {ex.Message}");
            }
        }

        /// <summary>
        /// delete danceDirection 
        /// </summary>
        /// <param name="danceDirection"></param>
        public async Task DeleteAsync(int danceDirectionId)
        {
            try
            {
                await _danceDirectionBase.DeleteAsync(danceDirectionId);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error product Delete(danceDirectiontId= {danceDirectionId}. Error: {ex.Message}");
            }
        }
    }
}
