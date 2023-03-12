using Database.Service;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Http;
using OnlineShop.WebApp.Models.Extensions;
using System.Threading.Tasks;
using Service;

namespace Domain.Views.Shared.Components.FavoriteMenuItem
{
    public class FavoriteMenuItemViewComponent:ViewComponent
    {
        private readonly IFavoriteProductsService productsFavoriteService;
        private readonly string currentUserId;

        public FavoriteMenuItemViewComponent(IFavoriteProductsService _productsFavoriteService, 
                                             IHttpContextAccessor httpContextAccessor)
        {
            productsFavoriteService = _productsFavoriteService;
            currentUserId = HttpContextExtension.GetCurentUserId(httpContextAccessor.HttpContext);
        }

        public async Task<IViewComponentResult> InvokeAsync(int productId, bool useBigMenuIcon = false)
        {
            var favoriteProducts = await productsFavoriteService.GetAllAsync(currentUserId);
            var favoriteProduct = favoriteProducts.FirstOrDefault(p => p.Id == productId);

            if (useBigMenuIcon)
            {
                if (favoriteProduct == null)
                    return View("AddFavoriteMenuItem", productId);

                return View("DeleteFavoriteMenuItem", productId);
            }

            if (favoriteProduct == null)
                return View("AddFavoriteMenuSmallItem", productId);

            return View("DeleteFavoriteMenuSmallItem", productId);
        }
    }
}
