using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;

namespace OnlineShop.WebApp.Models.Extensions
{
    /// <summary>
    /// Extension class for http context
    /// </summary>
    public static  class HttpContextExtension
    {
        /// <summary>
        /// Gets curent user id from context, or from cookies
        /// </summary>
        /// <param name="HttpContext"></param>
        /// <returns></returns>
        public static string GetCurentUserId(HttpContext HttpContext)
        {
            var currentUsers = HttpContext.User;
            string currentUserId = currentUsers.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            //Получаем идентификатор текущего пользователя из куки, если его там нет генерируем
            if (currentUserId == null)
            {
                var cookies = HttpContext.Request.Cookies;
                if (cookies.ContainsKey("notAutorizedUserGuid"))
                    currentUserId = cookies["notAutorizedUserGuid"];
                else
                {
                    currentUserId = Guid.NewGuid().ToString();
                    HttpContext.Response.Cookies.Append("notAutorizedUserGuid", currentUserId);
                }
            }

            return currentUserId;
        }
    }
}
