using Microsoft.AspNetCore.Identity;
using OnlineShop.Db.Models;
using OnlineShopWebAPI.Models;

namespace OnlineShopWebAPI
{
    public interface IUserService
    {
        bool IsValidUserInformationForAuth(AuthUser authUser, SignInManager<User> signInManager);
        bool IsValidUserInformationForRegister(RegUser registeringUser, UserManager<User> userManager);
    }
}
