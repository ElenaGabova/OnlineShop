using AutoMapper;
using Database.Models;
using Database.Service;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.WebApp.Models.Extensions;
using Domain.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ViewModels;

namespace Domain.Controllers
{
    public class FavoriteProductController : Controller
    {
        /// <summary>
        /// favorite Products service
        /// </summary>
        private readonly IFavoriteProductsService _favoriteProductService;

        /// <summary>
        /// products service
        /// </summary>
        private readonly IProductsService _productService;

        /// <summary>
        /// Current user Id
        /// </summary>
        private readonly string currentUserId;
        /// <summary>
        /// Auto mapper service
        /// </summary>
        private readonly IMapper _autoMapper;

        public FavoriteProductController(IFavoriteProductsService favoriteProductService,
                                         IProductsService productService,
                                         IHttpContextAccessor httpContextAccessor, 
                                         IMapper autoMapper)
        {
            _favoriteProductService = favoriteProductService;
            _productService = productService;
            currentUserId = HttpContextExtension.GetCurentUserId(httpContextAccessor.HttpContext);
            _autoMapper = autoMapper;
        }

        public async Task<ActionResult> Index()
        {
            var favoriteProducts = await _favoriteProductService.GetAllAsync(currentUserId);
            favoriteProducts = favoriteProducts.ToList();

            if (favoriteProducts == null || favoriteProducts.Count == 0)
                return View("TextPage", "В избранном нет товаров.");

            return View(_autoMapper.Map<List<ProductViewModel>>(favoriteProducts));
        }

        /// Add product to favorite
        public async Task<ActionResult> Add(int productId)
        {
            Product product = await _productService.TryGetByIdAsync(productId);
            await _favoriteProductService.AddAsync(currentUserId, product);
            return RedirectToAction("Index");
        }

        /// Delete product from favorite
        public async Task<ActionResult> Delete(int productId)
        {
            Product product = await _productService.TryGetByIdAsync(productId);
           await _favoriteProductService.RemoveAsync(currentUserId, product);
            return RedirectToAction("Index");
        }
    }
}
