using System;
using System.Collections.Generic;
using Database.Service;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Domain.Models;
using OnlineShop.WebApp.Models.Extensions;
using AutoMapper;
using System.Threading.Tasks;
using Service;
using ViewModels;

namespace Domain.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// All products collection
        /// </summary>
        private readonly IProductsService _productService;
        /// <summary>
        /// text page service
        /// </summary>
        private readonly ITextPageService _textPageService;

        private readonly IDanceDirectionService _danceDirectionService;

        /// <summary>
        /// auto mapper
        /// </summary>
        private readonly IMapper _autoMapper;

        public HomeController(IProductsService productService,
                              ITextPageService textPageService, 
                              IDanceDirectionService danceDirectionService,
                              IMapper autoMapper)
        {
            _productService = productService;
            _textPageService = textPageService;
            _danceDirectionService = danceDirectionService;
             _autoMapper = autoMapper;
        }


        /// <summary>
        /// Get All products
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ActionResult> Index()
        {
            var products = await _productService.GetAllProductsAsync();
            var productsViewModel = _autoMapper.Map<List<ProductViewModel>>(products);
            ViewBag.TextPageModel = _autoMapper.Map<TextPageViewModel>(_textPageService.GetTextPage());
            var danceDirections = await _danceDirectionService.GetAllDanceDirectionAsync();
            ViewBag.DanseDirectionViewModel = _autoMapper.Map<List<DanceDirectionViewModel>>(danceDirections);

            return View(productsViewModel);
        }
    }
}
