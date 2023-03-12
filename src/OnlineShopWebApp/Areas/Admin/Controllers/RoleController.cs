using Database.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.WebApp.Models.Extensions;
using OnlineShopWebApp.Areas.Admin.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Areas.Admin.Controllers
{
    [Area(DatabaseConstants.AdminRoleName)]
    [Authorize(Roles = DatabaseConstants.AdminRoleName)]
    public class RoleController : Controller
    {
        /// <summary>
        /// Roles service
        /// </summary>
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var roleList = _roleManager.
                             Roles.
                             Select(p => new RoleViewModel(p.Name)).
                             ToList();

            return View(roleList);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(nameof(Add), new RoleViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> Add(RoleViewModel role)
        {
            if (!ModelState.IsValid)
                return View(nameof(Add));

            var result = await _roleManager.CreateAsync(new IdentityRole(role.Name));
            if(result.Succeeded)
                return RedirectToAction(nameof(Index));
            else
            {
                var findrole = await _roleManager.FindByNameAsync(role.Name);
                if (findrole!= null)
                    ModelState.AddModelError("", "Роль с таким именем уже существует!");
            }

             return View(nameof(Add), role);
        }

        public async Task<ActionResult> Delete(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role != null)
                await _roleManager.DeleteAsync(role);

            return RedirectToAction(nameof(Index));
        }
    }
}
