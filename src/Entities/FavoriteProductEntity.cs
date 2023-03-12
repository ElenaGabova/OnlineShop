namespace Entities
{
    public class FavoriteProductEntity
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
        /// Favorite product 
        /// </summary>
        public ProductEntity Product { get; set; }
    }
}
