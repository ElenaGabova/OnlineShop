using AutoMapper;
using Domain;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service;
using System.Security.Claims;
using ViewModels;

namespace OnlineShopWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class OrderController : Controller
    {
        private readonly IMapper _autoMapper;
        private readonly IStoragesService _storageService;
        private readonly IOrdersService _ordersService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly Service.IUserDeliveryInfoService _userService;
        /// <summary>
        /// Current user Id
        /// </summary>
        private readonly string currentUserId;

        public OrderController(IMapper mapper, 
                               IStoragesService storageService,
                               IOrdersService ordersService,
                               IHttpContextAccessor httpContextAccessor,
                               IUserDeliveryInfoService userService)
        {
            this._autoMapper = mapper;
            this._storageService = storageService;
            this._ordersService = ordersService;
            this.httpContextAccessor = httpContextAccessor;
            this._userService = userService;

            currentUserId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

        [HttpPost("OrderRegistration")]
        public async Task<ActionResult> OrderRegistration(UserDeliveryInfoViewModel deliveryInfo)
        {

            if (ModelState.IsValid)
            {
                var userInfo = _autoMapper.Map<UserDeliveryInfo>(deliveryInfo);
                userInfo = await _userService.UpdateAsync(currentUserId, userInfo);

                var storage = await _storageService.TryGetByUserIdAsync(currentUserId);
                await _ordersService.AddAsync(userInfo, storage);
                await _storageService.DeleteStorageAsync(currentUserId);

               return Ok(new { Message = "Done" });
            }
            return BadRequest("Order is registrated!");
        }


        [HttpGet("GetAllOrders")]
        public async Task<List<Order>> Index()
        {
            var orders = await _ordersService.GetAllOrdersAsync();
            return orders;
        }

        [HttpGet("TryGetById")]
        public async Task<Order> TryGetById(Guid orderId)
        {
            var order = await _ordersService.TryGetByIdAsync(orderId);
            return order;
        }

    }
}