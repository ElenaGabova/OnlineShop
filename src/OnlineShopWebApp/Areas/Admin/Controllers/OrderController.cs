
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Database.Constants;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using System.Threading.Tasks;
using Service;
using ViewModels;

namespace Domain.Areas.Admin.Controllers
{
    [Area(DatabaseConstants.AdminRoleName)]
    [Authorize(Roles = DatabaseConstants.AdminRoleName)]
    public class OrderController : Controller
    {
        /// <summary>
        /// Orders service
        /// </summary>
        private readonly IOrdersService _ordersService;
        /// <summary>
        /// Auto mapper service
        /// </summary>
        private readonly IMapper _autoMapper;

        public OrderController(IOrdersService ordersService, IMapper autoMapper)
        {
            _ordersService = ordersService;
            _autoMapper = autoMapper;
        }

        public async Task<ActionResult> Index()
        {
            var orders = await _ordersService.GetAllOrdersAsync();
            return View(orders.Select(o =>_autoMapper.Map<OrderViewModel>(o)).ToList());
        }

        [HttpGet]
        public async Task<ActionResult> Details(int orderIndex, Guid orderId)
        {
            ViewBag.OrderIndex = orderIndex;
          
            var order = await _ordersService.TryGetByIdAsync(orderId);
            if (order != null)
                return View(_autoMapper.Map<OrderViewModel>(order));

            return View(nameof(Index));
        }

        [HttpPost]
        public async Task<ActionResult> UpdateStatus(OrderViewModel order)
        {
            if (!ModelState.IsValid)
                return View(nameof(Details), order);

            await _ordersService.UpdateStatusAsync(order.Id, (OrderStatus)order.Status);
            return RedirectToAction(nameof(Index));
        }

    }
}
