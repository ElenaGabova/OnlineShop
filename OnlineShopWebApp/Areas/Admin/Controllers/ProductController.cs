using AutoMapper;
using Database.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;

namespace Domain.Areas.Admin.Controllers
{
    [Area(DatabaseConstants.AdminRoleName)]
    [Authorize(Roles = DatabaseConstants.AdminRoleName)]
    public class ProductController : Controller
    {  
        /// <summary>
       /// Products service
       /// </summary>
        private readonly IProductsService _productService;
        /// <summary>
        /// App enviroment service
        /// </summary>
        private readonly IWebHostEnvironment _appEnviroment;  
        /// <summary>
        /// text page service
        /// </summary>
        private readonly ITextPageService _textPageService;

        private readonly IMapper _autoMapper;

        public ProductController(IProductsService productService, 
            IWebHostEnvironment appEnviroment,
            ITextPageService textPageService,
            IMapper autoMapper)
        {
            _productService = productService;
            _appEnviroment = appEnviroment;
            _textPageService = textPageService;
            _autoMapper = autoMapper;
        }

        public async Task<ActionResult> Index()
        {
            var products = await _productService.GetAllProductsAsync();
            products = products.Select(p => p).ToList();
            var productsViewModel = _autoMapper.Map<List<ProductViewModel>>(products);
         //   ViewBag.TextPageViewModel = _autoMapper.Map<TextPageViewModel>(_textPageService.GetTextPage());

            return View(productsViewModel);
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View(nameof(Edit), new ProductViewModel());
        }

        //[HttpPost]
        //public async Task<ActionResult> Edit(ProductViewModel productViewModel)
        //{
        //    var user = (User)httpContextAccessor.HttpContext.Items["User"];
        //    var product = await productsRepository.TryGetByIdAsync(productId);
        //    if (product != null)
        //    {
        //        await wishListsRepository.RemoveItemAsync(product, user.Id);
        //        await cartsRepository.AddAsync(product, user.Id);
        //        return Ok(new { Message = "Added" });
        //    }
        //    return BadRequest("Product did not found");
        //}

        [HttpGet]
        public async Task<ActionResult> Edit(int productId)
        {
            var product = await _productService.TryGetByIdAsync(productId);
            if (product != null)
                return View(_autoMapper.Map<ProductViewModel>(product));

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<ActionResult> Edit(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
                return View(productViewModel);

            if (productViewModel.UploadedFile != null)
                LoadNewImage(productViewModel);
            var product = _autoMapper.Map<Product>(productViewModel);
            await _productService.EditAsync(product);
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Delete(int productId)
        {
            await _productService.DeleteAsync(productId);
            return RedirectToAction(nameof(Index));
        }

        private void LoadNewImage(ProductViewModel productViewModel)
        {
            if (productViewModel.UploadedFile != null)
            {
                string productImagePath = Path.Combine(_appEnviroment.WebRootPath + "\\images\\products\\");
                if (!Directory.Exists(productImagePath))
                    Directory.CreateDirectory(productImagePath);

                string fileName = Guid.NewGuid() + "." + productViewModel.UploadedFile.FileName.Split('.').Last();
                using (var fileStream = new FileStream(productImagePath + fileName, FileMode.Create))
                {
                    productViewModel.UploadedFile.CopyTo(fileStream);
                }
                productViewModel.ImagePath = "images/products/" + fileName;
            }
        }

        
    }
}
