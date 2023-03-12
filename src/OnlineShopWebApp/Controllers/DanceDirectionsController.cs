using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using System.Collections.Generic;
using AutoMapper;
using System.Threading.Tasks;
using Service;
using Domain;
using ViewModels;

namespace Domain.Controllers
{
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

        public async Task<ActionResult> PageLesson(int id)
        {
            DanceDirection danceDirection = await _danceDirectionsService.TryGetByIdAsync(id);

            return View(_autoMapper.Map<DanceDirectionViewModel>(danceDirection));
        }
    }
}
