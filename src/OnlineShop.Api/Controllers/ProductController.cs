using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Service;
using ViewModels;

namespace OnlineShopWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {   
        /// <summary>
        /// Products service
        /// </summary>
        private readonly IProductsService _productService;
        /// <summary>
        /// Mapper service
        /// </summary>
        private readonly IMapper _autoMapper;

        public ProductController(IProductsService productService, IMapper autoMapper)
        {
            _productService = productService;
            _autoMapper = autoMapper;
        }


        [HttpGet("GetAllProducts")]
        public async Task<List<Product>> Index()
        {
            var products = await _productService.GetAllProductsAsync();
            return products;
        }

        [HttpGet("TryGetById")]
        public async Task<Product> TryGetById(int productId)
        {
            var product = await _productService.TryGetByIdAsync(productId);
            return product;
        }


        [HttpPut("Add")]
        public async Task<ActionResult> Add(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Please pass the valid product model");

            var product = _autoMapper.Map<Product>(productViewModel);
            await _productService.AddAsync(product);
            return Ok(new { Message = "Added" });
        }


        [HttpPut("Edit")]
        public async Task<ActionResult> Edit(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Please pass the valid product model");

            var product = _autoMapper.Map<Product>(productViewModel);
            await _productService.EditAsync(product);
            return Ok(new { Message = "Changed" });
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete(int productId)
        {
            await _productService.DeleteAsync(productId);
            return Ok(new { Message = "Deleted" });
        }
    }
}
