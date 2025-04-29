using Ecom.Data;
using Ecom.Data.Services;
using Ecom.Data.ViewModels;
using Ecom.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Ecom.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;

        public MoviesController(IMoviesService service)
        {
            _service = service;
        }

        //public async Task<IActionResult> Create()
        //{
        //    var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

        //    ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
        //    ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Create(NewMovieVM movie)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

        //        ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
        //        ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
        ////        return View(movie);
        ////    }

        //    //await _service.AddNewMovieAsync(movie);
        //    return RedirectToAction("Index");
        //}

        public async Task<IActionResult> Index()
        {
            var all = await _service.GetAllAsync();
            return View(all);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Movie movie)
        {
            await _service.AddAsync(movie);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            var data = await _service.GetByIdAsync(id);
            if (data == null) return View("NotFound");
            return View(data);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var data = await _service.GetByIdAsync(id);
            if (data == null) return View("NotFound");
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Movie movie)
        {
            await _service.UpdateAsync(id, movie);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var data = await _service.GetByIdAsync(id);
            if (data == null) return View("NotFound");
            return View(data);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Deleted(int id)
        {
            var data = _service.GetByIdAsync(id);
            if (data == null) return View("NotFound");
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        //public async Task<IActionResult> Filter(string searchString)
        //{
        //    var allMovies = await _service.GetAll(n => n.Cinema);

        //    if (!string.IsNullOrEmpty(searchString))
        //    {
        //        var filteredResult = allMovies.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();

        //        //var filteredResultNew = allMovies.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

        //        return View("Index", filteredResult);
        //    }

        //    return View("Index", allMovies);
        //}


    }
}
