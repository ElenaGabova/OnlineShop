using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Service;
using ViewModels;

namespace OnlineShop.WebApp.Views.Shared.Components.UserHeader
{
    public class UserHeaderViewComponent : ViewComponent
    {

        ITextPageService _textPageService;

        /// <summary>
        /// Auto mapper service
        /// </summary>
        private readonly IMapper _autoMapper;

        public UserHeaderViewComponent(ITextPageService textPageService, IMapper autoMapper)
        {
            _textPageService = textPageService;
            _autoMapper = autoMapper;
        }



        public IViewComponentResult Invoke(bool showHeader = true)
        {
            var textPage = _textPageService.GetTextPage();
            var textPageViewModel = _autoMapper.Map<TextPageViewModel>(textPage);

            if (showHeader)
                return View("PageHeader", textPageViewModel);
            else
                return View("PageFooter", textPageViewModel);
        }
    }
}
