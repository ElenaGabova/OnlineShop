using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class OrderController : Controller
    {
        private DatabaseContext databaseContext;
        private readonly IMapper mapper;
        private readonly ICartsRepository cartsRepository;
        private readonly IOrdersRepository ordersRepository;
        private readonly IHttpContextAccessor httpContextAccessor;
        public OrderController(DatabaseContext databaseContext, IMapper mapper, ICartsRepository cartsRepository, IOrdersRepository ordersRepository, IHttpContextAccessor httpContextAccessor)
        {
            this.databaseContext = databaseContext; 
            this.mapper = mapper;
            this.cartsRepository = cartsRepository;
            this.ordersRepository = ordersRepository;
            this.httpContextAccessor = httpContextAccessor;
        }

        [HttpPost("OrderRegistration")]
        public async Task<ActionResult> OrderRegistration(UserDeliveryInfoViewModel deliveryInfo)
        {
            if (ModelState.IsValid)
            {
                var user = (User)httpContextAccessor.HttpContext.Items["User"];
                var cart = await cartsRepository.TryGetCartAsync(user.Id);
                if (cart != null && cart.Items.Count != 0)
                {
                    var order = new Order
                    {
                        UserId = user.Id,
                        UserInfo = mapper.Map<UserDeliveryInfo>(deliveryInfo),
                        CartItems = cart.Items,
                    };
                    var price = 0;
                    foreach (var item in cart.Items)
                    {
                        price += item.Product.Cost * item.Count;
                    }
                    var promo = await databaseContext.Promocodes.FirstOrDefaultAsync(x => x.Text == deliveryInfo.PromocodeText);
                    if (promo != null)
                    {
                        price = price - (price * promo.Discount / 100);
                    }
                    order.FullPrice = price;
                    await ordersRepository.SaveOrderAsync(order);
                    await cartsRepository.RemoveCartAsync(cart);
                    return Ok(new { Message = "Done" });
                }
            }
            return BadRequest("Invalid user delibery information");
        }
    }
}