using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service;
using ViewModels;

namespace OnlineShopWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DanceDirectionsController : Controller
    {
        /// <summary>
        /// Products service
        /// </summary>
        private readonly IDanceDirectionService _danceDirectionsService;

        /// <summary>
        /// Auto Mapper service
        /// </summary>
        private readonly IMapper _autoMapper;

        public DanceDirectionsController(IDanceDirectionService danceDirectionsService, 
                                         IMapper autoMapper)
        {
            _danceDirectionsService = danceDirectionsService;
            _autoMapper = autoMapper;
        }

        [HttpGet("GetAll")]
        public async Task<List<DanceDirection>> GetAll()
        {
            var danceDirection = await _danceDirectionsService.GetAllDanceDirectionAsync();
            return danceDirection;
        }

        [HttpGet("TryGetById")]
        public async Task<DanceDirection> TryGetById(int danceDirectionId)
        {
            var danceDirection = await _danceDirectionsService.TryGetByIdAsync(danceDirectionId);
            return danceDirection;
        }

        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("Add")]
        public async Task<ActionResult> Add(DanceDirectionViewModel danceDirectionViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Please pass the valid danceDirection model");

            var danceDirection = _autoMapper.Map<DanceDirection>(danceDirectionViewModel);
            await _danceDirectionsService.AddAsync(danceDirection);
            return Ok(new { Message = "Added" });
        }

        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("Edit")]
        public async Task<ActionResult> Edit(DanceDirectionViewModel danceDirectionViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Please pass the valid danceDirection model");

            var danceDirection = _autoMapper.Map<DanceDirection>(danceDirectionViewModel);
            await _danceDirectionsService.EditAsync(danceDirection);
            return Ok(new { Message = "Changed" });
        }

        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete(int danceDirectionId)
        {
            await _danceDirectionsService.DeleteAsync(danceDirectionId);
            return Ok(new { Message = "Deleted" });
        }

    }
}
