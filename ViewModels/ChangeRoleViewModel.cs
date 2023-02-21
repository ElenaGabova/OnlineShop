using Microsoft.AspNetCore.Identity;
using OnlineShopWebApp.Areas.Admin.Models;
using System.Collections.Generic;

namespace OnlineShop.WebApp.Areas.Admin.Models
{
    /// <summary>
    /// Class for change role
    /// </summary>
    public class ChangeRoleViewModel
    {
        /// <summary>
        /// User name
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// User roles
        /// </summary>
        public List<RoleViewModel> UserRoles { get; set; }

        /// <summary>
        /// All Roles
        /// </summary>
        public List<RoleViewModel> AllRoles { get; set; }

        public ChangeRoleViewModel(string userName, List<RoleViewModel> userRoles, List<RoleViewModel> allRoles)
        {
            UserName = userName;
            UserRoles = userRoles;
            AllRoles = allRoles;
        }
    }
}
