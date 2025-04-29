using Ecom.Data;
using Ecom.Data.Services;
using Ecom.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecom.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;

        public ActorsController(IActorsService service)
        {
            _service = service;
        }
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
        public async Task<IActionResult> Create(Actor actor)
        {
            await _service.AddAsync(actor);
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
        public async Task<IActionResult> Edit(int id, Actor actor)
        {
            await _service.UpdateAsync(id, actor);
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

    }
}
