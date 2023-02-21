using Domain;
using Microsoft.AspNetCore.Identity;

namespace Service
{
    public interface IUserService
    {
        bool IsValidUserInformationForAuth(AuthUser authUser, SignInManager<User> signInManager);
        bool IsValidUserInformationForRegister(RegUser registeringUser, UserManager<User> userManager);
    }
}
