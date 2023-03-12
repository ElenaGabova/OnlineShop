using Microsoft.AspNetCore.Http;
using OnlineShopWebApp.Constants;
using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class DanceDirectionViewModel
    {   
        /// <summary>
        /// Direction id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Direction name
        /// </summary>
        /// 
        [Required(ErrorMessage = WebAppConstants.RequiredDirectionName)]
        public string Name { get; set; }

        [Required(ErrorMessage = WebAppConstants.RequiredDirectionDescription)]
        /// <summary>
        /// Directtion description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Direction main photo
        /// </summary>
        /// 

        public string? MainPhoto { get; set; }

        public IFormFile? UploadedFile { get; set; }

        /// <summary>
        /// Direction other photos
        /// </summary>
        public List<string>? OtherPhotos { get; set; }

        public IFormFile[]? OtherUploadedFiles { get; set; }

        /// <summary>
        /// Direction video links
        /// </summary>
        public List<string>? VideoLinks { get; set; }
        /// <summary>
        /// Solo double sign
        /// </summary>
        public bool SoloDoubleSign { get; set; } = false;
    }
}
