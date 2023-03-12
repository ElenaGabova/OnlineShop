using Microsoft.AspNetCore.Http;
using OnlineShopWebApp.Constants;
using System;
using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
   
    public class ProductViewModel
    {
        /// <summary>
        /// Product Id
        /// </summary>
        public int Id { get;  set; }

        /// <summary>
        /// Product Name
        /// </summary>
        /// 
        [Required(ErrorMessage = WebAppConstants.RequiredProductNameErrorText)]
        public string Name { get;  set; }

        /// <summary>
        /// Product cost
        /// </summary>
        /// 
        /// 
        [Required(ErrorMessage = WebAppConstants.RequiredProductCostErrorText)]
        [Range(1, 10000, ErrorMessage = WebAppConstants.ProductCostNotValidErrorText)]
        public decimal Сost { get;  set; }

        /// <summary>
        /// Product description
        /// </summary>
        /// 
        [Required(ErrorMessage = WebAppConstants.RequiredProductDescriptionErrorText)]
        public string? Description { get;  set; }

        /// <summary>
        /// Path of image
        /// </summary>
        public string? ImagePath { get; set; }

        /// <summary>
        /// User File
        /// </summary>
        public IFormFile? UploadedFile { get; set; }
    }
}
