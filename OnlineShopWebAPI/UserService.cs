using Microsoft.AspNetCore.Identity;
using OnlineShop.Db.Models;
using OnlineShopWebAPI.Models;

namespace OnlineShopWebAPI
{
    public class UserService : IUserService
    {
        public bool IsValidUserInformationForAuth(AuthUser authUser, SignInManager<User> signInManager)
        {
            var result = signInManager.PasswordSignInAsync(authUser.UserName, authUser.Password, false, false).Result; 
            return result.Succeeded;
        }
        public bool IsValidUserInformationForRegister(RegUser registeringUser, UserManager<User> userManager)
        {
            var user = new User { UserName = registeringUser.Email, Email = registeringUser.Email, PhoneNumber = registeringUser.Phone };
            var result = userManager.CreateAsync(user, registeringUser.Password).Result;
            return result.Succeeded;
        }
    }
}
