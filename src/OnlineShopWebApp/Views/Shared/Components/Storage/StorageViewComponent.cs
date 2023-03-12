using AutoMapper;
using Database.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.WebApp.Models.Extensions;
using Domain.Models;
using System.Threading.Tasks;
using ViewModels;
using Service;

namespace Domain.Views.Shared.Components
{
    public class StorageViewComponent: ViewComponent
    {

        /// <summary>
        /// Storage service
        /// </summary>
        private readonly IStoragesService _storageService;


        /// <summary>
        /// Auto mapper service
        /// </summary>
        private readonly IMapper _autoMapper;
        private readonly string currentUserId;

        public StorageViewComponent(IStoragesService storageService,
                                    IHttpContextAccessor httpContextAccessor,
                                    IMapper autoMapper)
        {
            _storageService = storageService;
            currentUserId = HttpContextExtension.GetCurentUserId(httpContextAccessor.HttpContext);
            _autoMapper = autoMapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var storage = await _storageService.TryGetByUserIdAsync(currentUserId);
            var storageViewModel = _autoMapper.Map<StorageViewModel>(storage);

            var productsCount = storageViewModel?.TotalAmount;
            if (productsCount == null || productsCount == 0)
                return View("Empty");

            return View("Storage", productsCount);
        }
    }
}
