using System;
namespace ViewModels
{
    public class FavoriteProductViewModel
    {
        /// <summary>
        /// id of favorite storage
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// User id of favorite storage
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Favorite products collection
        /// </summary>
        public ProductViewModel Product { get; set; }
    }
}
