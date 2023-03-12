using AutoMapper;
using Database.Constants;
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
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ViewModels;

namespace Domain.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        
        /// <summary>
        /// User info service
        /// </summary>
        private readonly Service.IUserDeliveryInfoService _userService;
        /// <summary>
        /// User service
        /// </summary>
        private readonly IOrdersService _orderService;

        private readonly UserManager<User> _userManager;
        /// <summary>
        /// Current user Id
        /// </summary>
        private readonly string currentUserId;
        
        /// <summary>
        /// Storage service
        /// </summary>
        private readonly IStoragesService _storageService;

        /// <summary>
        /// favorite Products service
        /// </summary>
        private readonly IFavoriteProductsService _favoriteProductService;

        /// <summary>
        /// httpContextService
        /// </summary>
        private readonly IHttpContextAccessor _httpContextService;
        /// <summary>
        /// Auto mapper service
        /// </summary>
        private readonly IMapper _autoMapper;

        public OrderController(IStoragesService storageService,
                               IUserDeliveryInfoService userService,
                               IOrdersService orderService,
                               UserManager<User> userManager,
                               IHttpContextAccessor httpContextAccessor,
                               IFavoriteProductsService favoriteProductService,
                               IMapper autoMapper)
        {
            _storageService = storageService;
            _userService = userService;
            _orderService = orderService;
            _userManager = userManager;
            currentUserId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            _httpContextService = httpContextAccessor;
            _favoriteProductService = favoriteProductService;
            _autoMapper = autoMapper;
        }

        public async Task<ActionResult> Index()
        {
            await CopyStorageAndFavoriteProductsNotAutorizedUser();
            var currentUser = await _userManager.FindByIdAsync(currentUserId);

            var storage = await _storageService.TryGetByUserIdAsync(currentUserId);
            ViewBag.Storage = _autoMapper.Map<StorageViewModel>(storage);
            return View("Index", new UserDeliveryInfoViewModel(currentUser.Id, 
                                                               currentUser.FirstName + " " + currentUser.SecondName, 
                                                               currentUser.PhoneNumber, 
                                                               currentUser.Email));

        }

      
        public async Task<ActionResult> Buy(UserDeliveryInfoViewModel userDeliveryInfo)
        {
            var userInfo =_autoMapper.Map<UserDeliveryInfo>(userDeliveryInfo);
            userInfo =  await _userService.UpdateAsync(currentUserId, userInfo);

            var storage = await _storageService.TryGetByUserIdAsync(currentUserId);
            await _orderService.AddAsync(userInfo, storage);
            await _storageService.DeleteStorageAsync(currentUserId);
            return View();
        }

        /// <summary>
        /// Копирование данных неавторизованного пользователя на авторизованного, если он вошел в систему
        /// </summary>
        /// <param name="notAutorizedUserId"></param>
        private async Task CopyStorageAndFavoriteProductsNotAutorizedUser()
        {
            //Куки из запроса
            var _requsetCookies = _httpContextService.HttpContext.Request.Cookies;

            //Получение ИД неавторизованного пользователя из кук
            string notAutorizedUserId = "";
            if (_requsetCookies.ContainsKey("notAutorizedUserGuid"))
                notAutorizedUserId = _requsetCookies["notAutorizedUserGuid"];

            if (string.IsNullOrEmpty(currentUserId) || string.IsNullOrEmpty(notAutorizedUserId))
                return;

            //Копирование корзины и избранных товаров от неавторизованного пользователя на авторизованного
            var notAutorizedUserFavoriteProducts = await _favoriteProductService.GetAllAsync(notAutorizedUserId);
            var notAutorizedUserStorage = await _storageService.TryGetByUserIdAsync(notAutorizedUserId);
            var autorizedUserFavoriteProducts = await _favoriteProductService.GetAllAsync(currentUserId);
            if (notAutorizedUserFavoriteProducts.Any() || notAutorizedUserStorage != null)
            {
                var addedFavoriteProducts = notAutorizedUserFavoriteProducts.
                                            Select(p => p).
                                            Where(p => !autorizedUserFavoriteProducts.Contains(p)).
                                            ToList();

                foreach(var product in addedFavoriteProducts)
                    await _favoriteProductService.AddAsync(currentUserId, product);

                foreach (var storage in notAutorizedUserStorage.Items)
                    await _storageService.AddAsync(currentUserId, storage.Product);
    
            }

            _httpContextService.HttpContext.Response.Cookies.Delete("notAutorizedUserGuid");
        }

    }
}
