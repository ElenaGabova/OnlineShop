using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace OnlineShopWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class FavoriteProductController : Controller
    {   
        /// <summary>
        /// Products service
        /// </summary>
        private readonly IProductsService _productService;

        /// <summary>
        /// favorite Products service
        /// </summary>
        private readonly IFavoriteProductsService _favoriteProductService;

        /// <summary>
        /// Mapper service
        /// </summary>
        private readonly IMapper _autoMapper;

        /// <summary>
        /// Current user Id
        /// </summary>
        private readonly string currentUserId;

        public FavoriteProductController(IFavoriteProductsService favoriteProductService,
                                          IProductsService productService,
                                          IHttpContextAccessor httpContextAccessor,
                                          IMapper autoMapper)
        {
            _favoriteProductService = favoriteProductService;
            _productService = productService;
            _autoMapper = autoMapper;

            var user = (User)httpContextAccessor.HttpContext.Items["User"];
            currentUserId = user.Id;
        }


        [HttpGet("GetAllProducts")]
        public async Task<List<Product>> Index()
        {
            var products = await _favoriteProductService.GetAllAsync(currentUserId);
            return products;
        }

        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("Add")]
        public async Task<ActionResult> Add(int productId)
        {   
            Product product = await _productService.TryGetByIdAsync(productId);
            await _favoriteProductService.AddAsync(currentUserId, product);
            return Ok(new { Message = "Added" });
        }

        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete(int productId)
        {
            Product product = await _productService.TryGetByIdAsync(productId);
            await _favoriteProductService.RemoveAsync(currentUserId, product);
            return Ok(new { Message = "Deleted" });
        }

        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete("Remove")]
        public async Task<ActionResult> Clear()
        {
            await _favoriteProductService.ClearAsync(currentUserId);
            return Ok(new { Message = "Removed" });
        }
    }
}
