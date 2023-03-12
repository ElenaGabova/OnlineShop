
using Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.WebApp.Models.Extensions;
using System.IO;

namespace OnlineShop.WebApp.Views.Shared.Components.UserImage
{
    public class UserImageViewComponent : ViewComponent
    {      
        /// User service
        /// </summary>
        private readonly UserManager<User> _userManager;
        /// <summary>
        /// Roles service
        /// </summary>
        private readonly RoleManager<IdentityRole> _roleManager;

        /// <summary>
        /// App enviroment service
        /// </summary>
        private readonly IWebHostEnvironment _appEnviroment;
        private string currentUserId;

        public UserImageViewComponent(UserManager<User> userManager,
                                RoleManager<IdentityRole> roleManager,
                                IWebHostEnvironment appEnviroment,
                                IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _appEnviroment = appEnviroment;

            currentUserId = HttpContextExtension.GetCurentUserId(httpContextAccessor.HttpContext);
        }

        public IViewComponentResult Invoke()
        {
           var currentUser = _userManager.FindByIdAsync(currentUserId).Result;
            if(currentUser!= null)
            {
                if(currentUser.ImagePath != null)
                {
                    if (File.Exists(_appEnviroment.WebRootPath +  currentUser.ImagePath))
                        return View("UserImage", new string(currentUser.ImagePath));
                } 
                
                return View("UserName", new string(currentUser.UserName));
            }

            return null;
        }

    }
}
