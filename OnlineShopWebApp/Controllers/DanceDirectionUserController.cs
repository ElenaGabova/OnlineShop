using AutoMapper;
using Database.Service;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Service;
using System;
using System.Threading.Tasks;
using ViewModels;

namespace OnlineShop.WebApp.Controllers
{
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

        [HttpGet]
        public IActionResult Index(int danceDirectionId)
        {
            ViewBag.danceDirectionId = danceDirectionId;
            return View("Index", new DanceDirectionUserViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> DanceDirectionRegistartion(DanceDirectionUserViewModel danceDirectionUserViewModel, int danceDirectionId )
        {
            if (!ModelState.IsValid)
                return View(nameof(Index), danceDirectionUserViewModel);
         
            var danceDirection =  await _danceDirectionsService.TryGetByIdAsync(danceDirectionId);
            var danceDirectionUser = _autoMapper.Map<DanceDirectionUser>(danceDirectionUserViewModel);
            danceDirectionUser = await _danceDirectionsUserService.AddAsync(danceDirectionUser);

            var danceDirectionRegistration =new DanceDirectionRegistration()
            {
                CreatedDateTime = DateTime.Now,
                DanceDirection = danceDirection,
                DanceDirectionUser = danceDirectionUser,
                NeedToCall = true
            };

           if (_danceDirectionRegistrationService.AddAsync(danceDirectionRegistration).IsFaulted)
              return View("TextPage", "Что-то пошло не так, повторите попытку похже");
           else
              return View("TextPage", "Спасибо, мы обязательно с вами свяжемся");
           
        }
    }
}
