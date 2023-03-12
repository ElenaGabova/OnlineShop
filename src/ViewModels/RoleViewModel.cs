using OnlineShopWebApp.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OnlineShopWebApp.Areas.Admin.Models
{
    public class RoleViewModel
    {

        /// <summary>
        /// Role Name
        /// </summary>
        /// 
        [Required(ErrorMessage = WebAppConstants.RequiredRoleName)]
        public string Name { get; set; }

        public RoleViewModel()
        {
        }

        /// <summary>
        /// Constructor for deserialize from json
        /// </summary>
        /// <param name="id">role id</param>
        /// <param name="name">role name</param>
        /// 
        [JsonConstructor]
        public RoleViewModel(string name)
        {
            Name = name;
        }
    }
}
