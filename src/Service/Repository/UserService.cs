using Microsoft.AspNetCore.Identity;
using Domain;

namespace Service.Repository
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
