using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Database.Constants;
using Microsoft.Extensions.Logging;
using AutoMapper;
using System.Threading.Tasks;
using Domain;
using ViewModels;
using OnlineShopWebApp.Areas.Autorization.Models;

namespace Domain.Areas.Autorization.Controllers
{
    [Area("Autorization")]
    public class AccountController : Controller
    {
        /// <summary>
        /// Autorization service
        /// </summary>
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger _logger;
        /// <summary>
        /// auto mapper service
        /// </summary>
        private readonly IMapper _autoMapper;

        public AccountController(UserManager<User> userManager,
            SignInManager<User> signInManager,
            ILogger<AccountController> logger, 
            IMapper autoMapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _autoMapper = autoMapper;
        }


        public IActionResult Login(string returnUrl)
        {
            return View(new Login() { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public async Task<ActionResult> Login(Login login)
        {
            if (!ModelState.IsValid)
                return View(nameof(Login));

            var result = await _signInManager.PasswordSignInAsync(login.UserName, login.Password, login.RememberMe, false);
            if (result.Succeeded)
            {
                if (login.ReturnUrl!= null)
                    return Redirect(login?.ReturnUrl);

                return RedirectToAction("Index", "home", new { area = "" });
            }
            else
            {
                var findUser = await _userManager.FindByNameAsync(login.UserName);
               if (findUser == null)
                    ModelState.AddModelError("", Constants.Constants.AutorizationNotFindUserErrorText);
               else
                    ModelState.AddModelError("", Constants.Constants.AutorizationNotValidPasswordErrorText);
            }

            return View(nameof(Login));
        }

        [HttpGet]
        public IActionResult Registration(string returnUrl)
        {
            return View(new RegisterViewModel() { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public async Task<ActionResult> Registration(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
                return View(nameof(Registration));
          
            User user = _autoMapper.Map<User>(register);
            // добавляем пользователя
            var result = await _userManager.CreateAsync(user, register.Password);
            await tryAssignUserRole(user);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);

                if (register.ReturnUrl != null)
                    return Redirect(register?.ReturnUrl);

                return RedirectToAction("Index", "home", new { area = "" });

            }
            else
            {
                ModelState.AddModelError("", Constants.Constants.RegistretionUserNameErrorText);
            }

            return View(nameof(Registration));
        }

        private async Task tryAssignUserRole(User user)
        {
            try
            {
                await _userManager.AddToRoleAsync(user, DatabaseConstants.UserRoleName);
            }
            catch
            {
                _logger.LogWarning("Произошла ошибка при добавлении роли пользователю" + user.UserName);
            }
        }

        /// <summary>
        /// Logout user
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "home", new { area = "" });
        }
    }
}
