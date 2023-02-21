using System;
using System.IO;

namespace Database.Constants
{
    public static class DatabaseConstants
    {
        public const string ProductFileName = "ProductData.json";
        public const string FavoriteProductFileName = "FavoriteProductData.json";
        public const string StorageFileName = "StorageData.json";
        public const string OrderFileName   = "OrderDataFileName.json";
        public const string UserInfoFileName = "UserInfoFileName.json";
        public const string AutorizationUsersFileName = "AccountFileName.json";
        public const string RolesFileName = "RolesFileName.json";
        public const string TextPagesFileName = "TextPagesFileName.json";

        public static string JsonFilePath = Path.GetDirectoryName(Environment.CurrentDirectory) /*+ /"D:\\C#\\Projects\\DansingPeople.OnlineShop\\OnlineShop\\DatabaseProject\\JsonFiles\\"*/;
       
        public const string AdminRoleName = "admin";
        public const string UserRoleName = "User";

        public static int UsersCount = 0;
    }
}
