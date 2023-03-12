using AutoMapper;
using Database.Models;
using Database.Service;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.WebApp.Models.Extensions;
using Domain.Models;
using Service;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using ViewModels;

namespace Domain.Controllers
{
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
        /// Current user Id
        /// </summary>
        private readonly string currentUserId;
        private readonly IMapper _autoMapper;

        public StorageController(IProductsService productService,
                                 IStoragesService storageService,
                                 IHttpContextAccessor httpContextAccessor, 
                                 IMapper autoMapper)
        {
            _productService = productService;
            _storageService = storageService;

            currentUserId = HttpContextExtension.GetCurentUserId(httpContextAccessor.HttpContext);
            _autoMapper = autoMapper;
        }

        public async Task<ActionResult> Index()
        {
            var storage = await _storageService.TryGetByUserIdAsync(currentUserId);
            var storageViewModel = _autoMapper.Map<StorageViewModel>(storage);
         
            if (storageViewModel == null || storageViewModel.IsEmpty)
                return View("TextPage", "Ваша корзина пуста.");
            
            return View(storageViewModel);
        }

        /// Add product in storage
        public async Task<ActionResult> AddProduct(int productId)
        {
            Product product = await _productService.TryGetByIdAsync(productId);
            await _storageService.AddAsync(currentUserId, product);
            return RedirectToAction("Index");
        }

        /// Delete product in storage
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<ActionResult> DeleteProduct(int productId)
        {
            Product product = await _productService.TryGetByIdAsync(productId);
            await _storageService.DeleteAsync(currentUserId, product);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Remove product in storage
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<ActionResult> RemoveProduct(int productId)
        {
            Product product = await _productService.TryGetByIdAsync(productId);
            await _storageService.RemoveAllPositionsAsync(currentUserId, product);
            return RedirectToAction("Index");
        }
    }
}
