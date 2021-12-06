using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OilShop.Models;
using OilShop.Repo.Implement;
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
        private readonly IOilRepo _oilRepo;
        public HomeController(ILogger<HomeController> logger, IOilRepo oilRepo)
        {
            _logger = logger;
            _oilRepo = oilRepo;
        }

        public IActionResult Index()
        {
            ViewBag.Oils = _oilRepo.GetAll();
            return View();
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
