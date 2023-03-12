using AutoMapper;
using Database.Constants;
using Database.Service;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Service;
using ViewModels;

namespace Domain.Areas.Admin.Controllers
{
    [Area(DatabaseConstants.AdminRoleName)]
    [Authorize(Roles = DatabaseConstants.AdminRoleName)]
    public class TextEditController : Controller
    {
        /// <summary>
        /// text page service
        /// </summary>
        private readonly ITextPageService _textPageService;
        private readonly IMapper _autoMapper;

        public TextEditController(ITextPageService textPageService, IMapper autoMapper)
        {
            _textPageService = textPageService;
            _autoMapper = autoMapper;
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View(nameof(Edit), _autoMapper.Map<TextPageViewModel>(_textPageService.GetTextPage()));
        }

        [HttpPost]
        public IActionResult Edit(TextPageViewModel textPage)
        {
            _textPageService.Edit(_autoMapper.Map<TextPage>(textPage));
            return View(nameof(AdminController.Index));
        }
    }
}
