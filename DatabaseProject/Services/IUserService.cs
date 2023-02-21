using Domain;
using Microsoft.AspNetCore.Identity;

namespace OnlineShopWebAPI
{
    public interface IUserService
    {
        bool IsValidUserInformationForAuth(AuthUser authUser, SignInManager<User> signInManager);
        bool IsValidUserInformationForRegister(RegUser registeringUser, UserManager<User> userManager);
    }
}
