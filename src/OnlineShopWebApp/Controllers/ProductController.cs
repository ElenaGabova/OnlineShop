using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using System.Collections.Generic;
using AutoMapper;
using System.Threading.Tasks;
using Service;
using Domain;
using ViewModels;

namespace Domain.Controllers
{
    public class ProductController : Controller
    {
        /// <summary>
        /// Products service
        /// </summary>
        private readonly IProductsService _productService;
        /// <summary>
        /// Auto Mapper service
        /// </summary>
        private readonly IMapper _autoMapper;

        public ProductController(IProductsService productService, 
                                 IMapper autoMapper)
        {
            _productService = productService;
            _autoMapper = autoMapper;
        }

        public async Task<ActionResult> Index(int id = 0)
        {
            Product product = await _productService.TryGetByIdAsync(id);
            if (product == null)
            {
                var products = await _productService.GetAllProductsAsync();
                return View(_autoMapper.Map<List<ProductViewModel>>(products));

            }
            return View(new List<ProductViewModel> { _autoMapper.Map<ProductViewModel>(product) });
        }
    }
}
