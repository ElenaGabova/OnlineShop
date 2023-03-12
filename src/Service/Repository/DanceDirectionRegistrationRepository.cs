using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Database.Service;
using Domain;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Database.Repository
{
    public class DanceDirectionRegistrationRepository : IDanceDirectionRegistrationService
    {
        private readonly IDanceDirectionRegistrationBase _danceDirectionRegistrationBase;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public DanceDirectionRegistrationRepository(IDanceDirectionRegistrationBase danceDirectionBase, IMapper mapper, ILogger<DanceDirectionRegistrationRepository> logger)
        {
            _danceDirectionRegistrationBase = danceDirectionBase;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Get  all danceDirections
        /// </summary>
        public async Task<List<DanceDirectionRegistration>> GetAll()
        {
            List<DanceDirectionRegistration> danceDirectionsRegistrations = new List<DanceDirectionRegistration>();
            try
            {
                List<DanceDirectionRegistrationEntity> danceDirectionEntities = await _danceDirectionRegistrationBase.GetAll();
                danceDirectionsRegistrations = _mapper.Map<List<DanceDirectionRegistration>>(danceDirectionEntities);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error DanceDirectionRegistration GetAll. Error: {ex.Message}");
            }

            return danceDirectionsRegistrations;
        }

        /// <summary>
        /// Try get DanceDirectionRegistration by id
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public async Task<DanceDirectionRegistration> TryGetByIdAsync(Guid danseDirectionRegistrationId)
        {
            DanceDirectionRegistration danceDirectionsRegistration = null;
            try
            {
                var danceDirectionRegistrationEntity = await _danceDirectionRegistrationBase.TryGetByIdAsync(danseDirectionRegistrationId);
                danceDirectionsRegistration = _mapper.Map<DanceDirectionRegistration>(danceDirectionRegistrationEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error danceDirection TryGetById. Error: {ex.Message}");
            }

            return danceDirectionsRegistration;
        }
       
        /// <summary>
        /// Add new danceDirection
        /// </summary>
        /// <param name="danceDirection"></param>
        public async Task AddAsync(DanceDirectionRegistration danceDirectionRegistration)
        {
            try
            {
                var danceDirectionRegistrationEntity = _mapper.Map<DanceDirectionRegistrationEntity>(danceDirectionRegistration);
                await _danceDirectionRegistrationBase.AddAsync(danceDirectionRegistrationEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error danceDirectionRegistration Add(productId= {danceDirectionRegistration.Id}. Error: {ex.Message}");
                throw new Exception($"Error danceDirectionRegistration Add(productId= {danceDirectionRegistration.Id}. Error: {ex.Message}");
            }
        }


        /// <summary>
        /// Change order status by orderId
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="orderStatus"></param>
        public async Task UpdateAsync(Guid danseDirectionRegistrationId, bool needToContact)
        {
            try
            {
                await _danceDirectionRegistrationBase.UpdateAsync(danseDirectionRegistrationId, needToContact);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in order UpdateDanseDirectionRegistration({danseDirectionRegistrationId}, {needToContact}). Error: {ex.Message}");
            }
        }
    }
}
