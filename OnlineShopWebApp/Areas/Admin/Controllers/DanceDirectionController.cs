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
    public class DanceDirectionController : Controller
    {  
        /// <summary>
       /// Products service
       /// </summary>
        private readonly IDanceDirectionService _danceDirectionService;
        /// <summary>
        /// App enviroment service
        /// </summary>
        private readonly IWebHostEnvironment _appEnviroment;  
        /// <summary>
        /// text page service
        /// </summary>
        private readonly ITextPageService _textPageService;

        private readonly IMapper _autoMapper;

        public DanceDirectionController(IDanceDirectionService danceDirectionService, 
            IWebHostEnvironment appEnviroment,
            ITextPageService textPageService,
            IMapper autoMapper)
        {
            _danceDirectionService = danceDirectionService;
            _appEnviroment = appEnviroment;
            _textPageService = textPageService;
            _autoMapper = autoMapper;
        }

        public async Task<ActionResult> Index()
        {
            var danceDirections = await _danceDirectionService.GetAllDanceDirectionAsync();
            danceDirections = danceDirections.Select(p => p).ToList();
            var danceDirectionsViewModel = _autoMapper.Map<List<DanceDirectionViewModel>>(danceDirections);

            return View(danceDirectionsViewModel);
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View(nameof(Edit), new DanceDirectionViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> Add(DanceDirectionViewModel danceDirectionViewModel)
        {
            if (!ModelState.IsValid)
                return View(nameof(Edit), danceDirectionViewModel);

            LoadNewImage(danceDirectionViewModel);
            var danceDirection = _autoMapper.Map<DanceDirection>(danceDirectionViewModel);
            await _danceDirectionService.AddAsync(danceDirection);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int danceDirectionId)
        {
            var danceDirection = await _danceDirectionService.TryGetByIdAsync(danceDirectionId);
            if (danceDirection != null)
                return View(_autoMapper.Map<DanceDirectionViewModel>(danceDirection));

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<ActionResult> Edit(DanceDirectionViewModel danceDirectionViewModel)
        {
            if (!ModelState.IsValid)
                return View(danceDirectionViewModel);

            LoadNewImage(danceDirectionViewModel);
            var danceDirection = _autoMapper.Map<DanceDirection>(danceDirectionViewModel);
            await _danceDirectionService.EditAsync(danceDirection);
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Delete(int danceDirectionId)
        {
            await _danceDirectionService.DeleteAsync(danceDirectionId);
            return RedirectToAction(nameof(Index));
        }

        private void LoadNewImage(DanceDirectionViewModel danceDirectionViewModel)
        {
            if (danceDirectionViewModel.UploadedFile != null)
            {
                string productImagePath = Path.Combine(_appEnviroment.WebRootPath + "\\images\\danceDirections\\");
                if (!Directory.Exists(productImagePath))
                    Directory.CreateDirectory(productImagePath);

                string fileName = Guid.NewGuid() + "." + danceDirectionViewModel.UploadedFile.FileName.Split('.').Last();
                using (var fileStream = new FileStream(productImagePath + fileName, FileMode.Create))
                {
                    danceDirectionViewModel.UploadedFile.CopyTo(fileStream);
                }
                danceDirectionViewModel.MainPhoto = "images/danceDirections/" + fileName;
            }

            if (danceDirectionViewModel.OtherUploadedFiles != null)
            {
                foreach(var photo in danceDirectionViewModel.OtherUploadedFiles)
                {
                    string productImagePath = Path.Combine(_appEnviroment.WebRootPath + "\\images\\danceDirections\\");
                    if (!Directory.Exists(productImagePath))
                        Directory.CreateDirectory(productImagePath);

                    string fileName = Guid.NewGuid() + "." + photo.FileName.Split('.').Last();
                    using (var fileStream = new FileStream(productImagePath + fileName, FileMode.Create))
                    {
                        photo.CopyTo(fileStream);
                    }
                    danceDirectionViewModel.OtherPhotos.Add("images/danceDirections/" + fileName);
                }
            }
        }

        
    }
}
