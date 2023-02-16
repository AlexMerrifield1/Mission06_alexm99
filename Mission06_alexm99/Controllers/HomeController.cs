using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission06_alexm99.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_alexm99.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieContext _blahContext { get; set; }


        public HomeController(ILogger<HomeController> logger, MovieContext someName)

        {
            _logger = logger;
            _blahContext = someName;

        }


        [HttpGet]
        public IActionResult MyPodcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieEntry()
        {
            ViewBag.Categories = _blahContext.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult MovieEntry(Movies me)
        { 
            if (ModelState.IsValid)
            {
                _blahContext.Add(me);
                _blahContext.SaveChanges();
                return View();
            }
            else //If Invalid
            {
                ViewBag.Categories = _blahContext.Categories.ToList();

                return View(me);
            }
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