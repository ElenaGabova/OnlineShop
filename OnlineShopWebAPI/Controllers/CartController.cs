using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp;

namespace OnlineShopWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class CartController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly ICartsRepository cartsRepository;
        private readonly IWishListsRepository wishListsRepository;
        private readonly IHttpContextAccessor httpContextAccessor;
        public CartController(IProductsRepository productsRepository, ICartsRepository cartsRepository, IWishListsRepository wishListsRepository, IHttpContextAccessor httpContextAccessor)
        {
            this.productsRepository = productsRepository;
            this.cartsRepository = cartsRepository;
            this.wishListsRepository = wishListsRepository;
            this.httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("GetCart")]
        public async Task<Cart> GetCart()
        {
            var user = (User)httpContextAccessor.HttpContext.Items["User"];
            var cart = await cartsRepository.TryGetCartAsync(user.Id);
            return cart;
        }

        [HttpPost("AddProductInCart")]
        public async Task<ActionResult> AddProduct(Guid productId)
        {
            var user = (User)httpContextAccessor.HttpContext.Items["User"];
            var product = await productsRepository.TryGetByIdAsync(productId);
            if (product != null)
            {
                await wishListsRepository.RemoveItemAsync(product, user.Id);
                await cartsRepository.AddAsync(product, user.Id);
                return Ok(new { Message = "Added" });
            }
            return BadRequest("Product did not found");
        }


        [HttpPost("RemoveProductFromCart")]
        public async Task<ActionResult> RemoveProduct(Guid productId)
        {
            var user = (User)httpContextAccessor.HttpContext.Items["User"];
            var product = await productsRepository.TryGetByIdAsync(productId);
            if (product != null)
            {
                await cartsRepository.RemoveCartItemAsync(product, user.Id);
                return Ok(new { Message = "Removed" });
            }
            return BadRequest("Product did not found");
        }


        [HttpPost("ClearCart")]
        public async Task<ActionResult> ClearCart()
        {
            var user = (User)httpContextAccessor.HttpContext.Items["User"];
            var cart = await cartsRepository.TryGetCartAsync(user.Id);
            if (cart != null) 
            {
                await cartsRepository.ClearCartAsync(cart);
                return Ok(new { Message = "Cleared" });
            }
            return BadRequest("Cart did not found");
        }
    }
}
