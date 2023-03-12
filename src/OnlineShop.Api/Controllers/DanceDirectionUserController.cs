using AutoMapper;
using Database.Service;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service;
using System;
using System.Threading.Tasks;
using ViewModels;

namespace OnlineShop.WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DanceDirectionUserController : Controller
    {      
        // <summary>
        /// Products service
        /// </summary>
        private readonly IDanceDirectionService _danceDirectionsService;

        // <summary>
        /// Products service
        /// </summary>
        private readonly IDanceDirectionUserService _danceDirectionsUserService;
        /// <summary>
        /// Auto Mapper service
        /// </summary>
        private readonly IMapper _autoMapper;

        private readonly IDanceDirectionRegistrationService _danceDirectionRegistrationService;

        public DanceDirectionUserController(IDanceDirectionService danceDirectionsService, 
                                            IDanceDirectionUserService danceDirectionsUserService,
                                            IDanceDirectionRegistrationService danceDirectionRegistrationService,
                                            IMapper autoMapper)
        {
            _danceDirectionsService = danceDirectionsService; 
            _danceDirectionsUserService = danceDirectionsUserService;
            _danceDirectionRegistrationService = danceDirectionRegistrationService;
             _autoMapper = autoMapper;
        }

        [HttpGet("GetAll")]
        public async Task<List<DanceDirectionRegistration>> GetAll()
        {
            var danceDirection = await _danceDirectionRegistrationService.GetAll();
            return danceDirection;
        }

        [HttpGet("TryGetById")]
        public async Task<DanceDirectionRegistration> TryGetById(Guid registartionId)
        {
            var danceDirection = await _danceDirectionRegistrationService.TryGetByIdAsync(registartionId);
            return danceDirection;
        }

        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("Add")]
        public async Task<ActionResult> Add(DanceDirectionRegistration danceDirectionRegistartionViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Please pass the valid danceDirection model");

            var danceDirectionRegistartion = _autoMapper.Map<DanceDirectionRegistration>(danceDirectionRegistartionViewModel);
            await _danceDirectionRegistrationService.AddAsync(danceDirectionRegistartion);
            return Ok(new { Message = "Added" });
        }

        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("Update")]
        public async Task<ActionResult> UpdateAsync(Guid danceDirectionRegistartionId, bool needtoContact)
        {
            await _danceDirectionRegistrationService.UpdateAsync(danceDirectionRegistartionId, needtoContact);
            return Ok(new { Message = "Changed" });
        }
    }
}
