using Dozen2MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Dozen2MVC.Controllers
{
    /*
        IMPORTANT
        Controllers get recreated for each request and response which means:
            if you want to save customer data, location data, and all the data, and youre navigating different views to choose those,
            youre gonna have to find a way to save them. Such as sessions:
                TempData, ViewBag, ViewData
            
            TempData cant store complex objects for long periods of time
       
     */
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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
