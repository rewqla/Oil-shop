using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OilShop.Helpers;
using OilShop.Models;
using OilShop.Models.Oil;
using OilShop.Repo.Implement;
using OilShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OilShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOilService _oilService;
        public HomeController(ILogger<HomeController> logger, IOilService oilService)
        {
            _logger = logger;
            _oilService = oilService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Oils = _oilService.GetAll();
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ReplaceOilViewModel model)
        {
            if (ModelState.IsValid)
            {
                _oilService.Create(model);
                return Redirect("/");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(long Id)
        {
            _oilService.Delete(Id);
            return Redirect("/");
        }


        [HttpGet]
        public IActionResult Update(long Id)
        {
            var model = _oilService.GetByIdFull(Id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(ReplaceOilViewModel model)
        {
            if (ModelState.IsValid)
            {
                _oilService.Update(model);
                return Redirect("/");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Details(long Id)
        {
            var model = _oilService.GetByIdFull(Id);
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
