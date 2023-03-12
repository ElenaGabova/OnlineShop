using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Domain.Models;
using Service;
using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ViewModels;
using OnlineShopWebApp.Areas.Autorization.Models;

namespace OnlineShop.WebApp.Areas.Personal.Controllers
{
    [Area("Personal")]
    public class PersonController : Controller
    {
        /// <summary>
        /// Orders servise
        /// </summary>
        private readonly IOrdersService _ordersService;
        /// User service
        /// </summary>
        private readonly UserManager<User> _userManager;
        /// <summary>
        /// Roles service
        /// </summary>
        private readonly RoleManager<IdentityRole> _roleManager;
        /// <summary>
        /// Logger service
        /// </summary>
        private readonly ILogger _logger;
        /// <summary>
        /// App enviroment service
        /// </summary>
        private readonly IWebHostEnvironment _appEnviroment; 
        /// <summary>
        /// Auto mapper service
        /// </summary>
        private readonly IMapper _autoMapper;
        private string currentUserId;

        public PersonController(UserManager<User> userManager, 
                                RoleManager<IdentityRole> roleManager, 
                                ILogger<PersonController> logger,
                                IOrdersService ordersService,
                                IWebHostEnvironment appEnviroment,
                                IHttpContextAccessor httpContextAccessor,
                                IMapper autoMapper)
        {
            _ordersService = ordersService;
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
            _appEnviroment = appEnviroment;
            _autoMapper = autoMapper;
            var currentUsers = httpContextAccessor.HttpContext.User;
            currentUserId = currentUsers.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public async Task<ActionResult> Edit()
        {
            var user = await _userManager.FindByIdAsync(currentUserId);
            if (user == null)
                return View(nameof(Index));
            return View(_autoMapper.Map<RegisterViewModel>(user));
        }

        [HttpPost]
        public async Task<ActionResult> Edit(RegisterViewModel userInfo)
        { 
            User user =await  _userManager.FindByNameAsync(userInfo.UserName);
            if (user != null)
            {
                user.FirstName = userInfo.FirstName;
                user.SecondName = userInfo.SecondName;
                user.UserName = userInfo.UserName;
                user.PhoneNumber = userInfo.PhoneNumber;
                
                if(userInfo.UploadedFile != null)
                {
                    LoadNewImage(userInfo);
                    user.ImagePath = userInfo.ImagePath;
                }
                await _userManager.UpdateAsync(user);
            }

            return RedirectToAction("Index", "home", new { area = "" });
        }

        public async Task<ActionResult> Orders()
        {
            var orders = await _ordersService.GetAllOrdersAsync();
            var ordersEntity = orders.Where(o => o.User.Id.Equals(currentUserId)).
                               Select(o => _autoMapper.Map<OrderViewModel>(o)).
                               ToList();
            return View(ordersEntity);
        }

        public async Task<ActionResult> DeleteUserImage()
        {
            var user = await _userManager.FindByIdAsync(currentUserId);
            if (user == null)
                return View(nameof(Index));

            if (user.ImagePath!= null)
            {
                if (System.IO.File.Exists(user.ImagePath))
                    Directory.Delete(user.ImagePath, true);
                   
                user.ImagePath = String.Empty;
                await _userManager.UpdateAsync(user);
            }
            return View(nameof(Edit), _autoMapper.Map<RegisterViewModel>(user));
        }

        /// <summary>
        /// Load new image for user
        /// </summary>
        /// <param name="userInfo"></param>
        private void LoadNewImage(RegisterViewModel userInfo)
        {
            if (userInfo.UploadedFile != null)
            {
                string userFolederName = "\\images\\users\\";
                string productImagePath = Path.Combine(_appEnviroment.WebRootPath + userFolederName);
                if (!Directory.Exists(productImagePath))
                    Directory.CreateDirectory(productImagePath);

                string fileName = Guid.NewGuid() + "." + userInfo.UploadedFile.FileName.Split('.').Last();
                using (var fileStream = new FileStream(productImagePath + fileName, FileMode.Create))
                {
                    userInfo.UploadedFile.CopyTo(fileStream);
                }
                userInfo.ImagePath = userFolederName + fileName;
            }
        }
    }
}
