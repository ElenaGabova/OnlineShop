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
    public class StorageController : Controller
    {
        /// <summary>
        /// Products service
        /// </summary>
        private readonly IProductsService _productService;

        /// <summary>
        /// Storage service
        /// </summary>
        private readonly IStoragesService _storageService;

        /// <summary>
        /// Http contxt acessor
        /// </summary>
        private readonly IHttpContextAccessor _httpContextAccessor;
  
        private readonly IMapper _autoMapper;

        public StorageController(IProductsService productService,
                                IStoragesService storageService,
                                IHttpContextAccessor httpContextAccessor,
                                IMapper autoMapper)
        {
            _productService = productService;
            _storageService = storageService;
            _httpContextAccessor = httpContextAccessor;
            _autoMapper = autoMapper;
        }

        [HttpGet("GetStorage")]
        public async Task<Storage> GetStorage()
        {
            var user = (User)_httpContextAccessor.HttpContext.Items["User"];
            var storage = await _storageService.TryGetByUserIdAsync(user.Id);
            return storage;
        }

        [HttpPost("AddProduct")]
        public async Task<ActionResult> AddProduct(int productId)
        {
            var user = (User)_httpContextAccessor.HttpContext.Items["User"];
            var product = await _productService.TryGetByIdAsync(productId);
            if (product != null)
            {
                await _storageService.AddAsync(user.Id, product);
                return Ok(new { Message = "Added" });
            }
            return BadRequest("Product did not found");
        }


        [HttpDelete("RemoveProductFromStorage")]
        public async Task<ActionResult> RemoveProduct(int productId)
        {
            var user = (User)_httpContextAccessor.HttpContext.Items["User"];
            var product = await _productService.TryGetByIdAsync(productId);
            if (product != null)
            {
                await _storageService.DeleteAsync(user.Id,product);
                return Ok(new { Message = "Removed" });
            }
            return BadRequest("Product did not found");
        }


        [HttpDelete("ClearStorage")]
        public async Task<ActionResult> ClearCart()
        {
            var user = (User)_httpContextAccessor.HttpContext.Items["User"];
            var storage = await _storageService.TryGetByUserIdAsync(user.Id);
            if (storage != null)
            {
                await _storageService.DeleteStorageAsync(user.Id);
                return Ok(new { Message = "Cleared" });
            }
            return BadRequest("Storage did not found");
        }
    }
}
