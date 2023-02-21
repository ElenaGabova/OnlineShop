using Database.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using OnlineShop.WebApp.Areas.Admin.Models;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using AutoMapper;
using System.Threading.Tasks;
using OnlineShopWebApp.Areas.Autorization.Models;
using OnlineShopWebApp.Areas.Admin.Models;

namespace Domain.Areas.Admin.Controllers
{
    [Area(DatabaseConstants.AdminRoleName)]
    [Authorize(Roles = DatabaseConstants.AdminRoleName)]
    public class UserController : Controller
    {
        /// <summary>
        /// User service
        /// </summary>
        private readonly UserManager<User> _userManager;
        /// <summary>
        /// Roles service
        /// </summary>
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger _logger;
        /// <summary>
        /// Auto mapper service
        /// </summary>
        private readonly IMapper _autoMapper;

        public UserController(UserManager<User> userManager, 
                              RoleManager<IdentityRole> roleManager, 
                              ILogger<UserController> logger, 
                              IMapper autoMapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
            _autoMapper = autoMapper;
        }

        public IActionResult Index()
        {
            var usersList = _userManager.
                             Users.
                             Select(p => _autoMapper.Map<RegisterViewModel>(p)).
                             ToList();
            return View(usersList);
        }

        public async Task<ActionResult> Details(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
                return View(nameof(Index));

            return View(_autoMapper.Map<RegisterViewModel>(user));
        }

        [HttpGet]
        public async Task<ActionResult> Edit(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
                return View(nameof(Index));

            return View(_autoMapper.Map<RegisterViewModel>(user));
        }

        [HttpPost]
        public async Task<ActionResult> Edit(RegisterViewModel userInfo)
        {

            User user = _userManager.FindByNameAsync(userInfo.UserName).Result;
            if (user != null)
            {
                user.FirstName = userInfo.FirstName;
                user.SecondName = userInfo.SecondName;
                user.UserName = userInfo.UserName;
                user.PhoneNumber = userInfo.PhoneNumber;
                await _userManager.UpdateAsync(user);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Delete(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user != null)
               await _userManager.DeleteAsync(user);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<ActionResult> ChangePassword(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
                return View(nameof(Index));

            return View(new ChangePassword() { UserName = userName });
        }

        [HttpPost]
        public async Task<ActionResult> ChangePassword(ChangePassword changePasswordInfo)
        {
            if (!ModelState.IsValid)
                return View(changePasswordInfo);

            var user = await _userManager.FindByNameAsync(changePasswordInfo.UserName);
            if (user != null)
            {
                await _userManager.RemovePasswordAsync(user);
                await _userManager.AddPasswordAsync(user, changePasswordInfo.Password);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<ActionResult> EditRight(string userName)
        {
            var user  = await _userManager.FindByNameAsync(userName);
            var roles = await _userManager.GetRolesAsync(user);
            var allRoles = _roleManager.Roles.ToList();

            return View(new ChangeRoleViewModel(userName,
                                                roles.Select(r => new RoleViewModel(r)).ToList(),
                                                allRoles.Select(a => new RoleViewModel(a.Name)).ToList()));
        }


        [HttpPost]
        public async Task<ActionResult> EditRight(string name, Dictionary<string, string> userRolesViewModel)
        {
            var user = await _userManager.FindByNameAsync(name);
            var newUserRoles = userRolesViewModel.Keys;
            var oldUserRoles = await _userManager.GetRolesAsync(user);

            try
            {
                await _userManager.RemoveFromRolesAsync(user, oldUserRoles);
                await _userManager.AddToRolesAsync(user, newUserRoles);
            }
            catch
            {
                _logger.LogWarning("Произошла ошибка при изменении ролей у пользователя" + user.UserName);
            }

            return Redirect($"/Admin/User/Details?userName={name}");

        }
    }
}
