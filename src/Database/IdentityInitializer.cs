using Database.Constants;
using Domain;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Database
{
    public class IdentityInitializer
    {
        public static async Task Initialize(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminEmail = "admin@gmail.com";
            string password = "Test1!";
            string firstName = "Админ";
            string secondName = "Админович";
            string phoneNumber = "11111111111";

            if (await roleManager.FindByNameAsync(DatabaseConstants.AdminRoleName) == null)
            {
                 await roleManager.CreateAsync(new IdentityRole(DatabaseConstants.AdminRoleName));
            }
            if (await roleManager.FindByNameAsync(DatabaseConstants.UserRoleName) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(DatabaseConstants.UserRoleName));
            }
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                User admin =  new User
                {
                    Email = adminEmail,
                    UserName = adminEmail,
                    FirstName = firstName,
                    SecondName = secondName,
                    PhoneNumber = phoneNumber
                };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                     userManager.AddToRoleAsync(admin, DatabaseConstants.AdminRoleName).Wait();
                }
            }  
        }
    }
}
