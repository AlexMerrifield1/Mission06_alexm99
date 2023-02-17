using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private MovieContext _blahContext { get; set; }

        public HomeController(MovieContext someName)
        {
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
        [HttpGet]
        public IActionResult MovieList()
        {
               // .Include(x => x.Major)
            var movies = _blahContext.Movies
                .Include(x => x.Category)
                .OrderBy(x => x.Category)
                .ToList();
            return View(movies);
        }

        //Edit Get/Post
        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.Categories = _blahContext.Categories.ToList();

            var movie = _blahContext.Movies.Single(x => x.MovieID == movieid);

            return View("MovieEntry", movie);
        }
        [HttpPost]
        public IActionResult Edit(Movies me)
        {
            _blahContext.Update(me);
            _blahContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

        //Delete Get/Post
        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var movie = _blahContext.Movies.Single(x => x.MovieID == movieid);

            return View(movie);
        }
        [HttpPost]
        public IActionResult Delete(Movies m)
        {
            _blahContext.Movies.Remove(m);
            _blahContext.SaveChanges();

            return RedirectToAction("MovieList");
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