using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Service;
using ViewModels;

namespace Domain.Controllers
{
    public class TextPageController : Controller
    {
        /// <summary>
        /// text page service
        /// </summary>
        private readonly ITextPageService _textPageService;
        private readonly IMapper _autoMapper;

        public TextPageController(ITextPageService textPageService,
                                  IMapper autoMapper)
        {
            _textPageService = textPageService;
            _autoMapper = autoMapper;
        }

        public IActionResult Directions()
        {
            return View(_autoMapper.Map<TextPageViewModel>(_textPageService.GetTextPage()));
        }
        public IActionResult AboutUs()
        {
            return View(_autoMapper.Map<TextPageViewModel>(_textPageService.GetTextPage()));
        }
    }
}
