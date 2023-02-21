
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Database.Constants;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using System.Threading.Tasks;
using Service;
using ViewModels;
using Database.Service;

namespace Domain.Areas.Admin.Controllers
{
    [Area(DatabaseConstants.AdminRoleName)]
    [Authorize(Roles = DatabaseConstants.AdminRoleName)]
    public class DanceDirectionLessonController : Controller
    {
        /// <summary>
        /// Orders service
        /// </summary>
        private readonly IDanceDirectionRegistrationService _danceRegistrationService;
        /// <summary>
        /// Auto mapper service
        /// </summary>
        private readonly IMapper _autoMapper;

        public DanceDirectionLessonController(IDanceDirectionRegistrationService danceRegistrationService, IMapper autoMapper)
        {
            _danceRegistrationService = danceRegistrationService;
            _autoMapper = autoMapper;
        }

        public async Task<ActionResult> Index()
        {
            var danceDirections = await _danceRegistrationService.GetAll();
            return View(danceDirections.Select(o =>_autoMapper.Map<DanceDirectionRegistrationViewModel>(o)).ToList());
        }

        [HttpGet]
        public async Task<ActionResult> UpdateStatus(Guid danceRegistrationId)
        {
            var danceDirection = await _danceRegistrationService.TryGetByIdAsync(danceRegistrationId);
            await _danceRegistrationService.UpdateAsync(danceRegistrationId, !danceDirection.NeedToCall);
            return RedirectToAction("Index");
        }
    }
}
