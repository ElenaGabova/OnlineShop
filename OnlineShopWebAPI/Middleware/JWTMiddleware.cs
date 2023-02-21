using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using OnlineShop.Db.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace OnlineShopWebAPI.Middleware
{
    public class JWTMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IConfiguration configuration;

        public JWTMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            this.next = next;
            this.configuration = configuration;
        }

        public async Task Invoke(HttpContext context, UserManager<User> userManager)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            
            if (token != null)
                attachAccountToContext(context, token, userManager);

            await next(context);
        }

        private void attachAccountToContext(HttpContext context, string token, UserManager<User> userManager)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(configuration["Jwt:Key"]);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidateIssuer = true,
                    ValidAudience = configuration["Jwt:Audience"],
                    ValidateAudience = true,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);
                var jwtToken = (JwtSecurityToken)validatedToken;
                var userEmail = jwtToken.Claims.First(x => x.Type == "email").Value;
                var user = userManager.FindByEmailAsync(userEmail).Result;
                context.Items["User"] = user;
            }
            catch { }
        }
    }
}
