using AspNetCoreCars.Models;
using AspNetCoreCars.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreCars.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarItemService _carItemService;

        // Acts a constructor for the class
        public CarsController(ICarItemService carItemService)
        {
            _carItemService = carItemService;
        }

        public async Task<IActionResult> Index() // This is an Index Action. Routes handled by controllers are alled actions.
        {
            var items = await _carItemService.GetCarItemsAsync();

            // Put items into a model
            var model = new CarViewModel()
            {
                Items = items
            };


            // Render view using the model
            return View(model);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItem(CarItem newCarItem)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var successful = await _carItemService.AddCarItemAsync(newCarItem);
            if (!successful)
            {
                return BadRequest("Could not add item.");
            }
            return RedirectToAction("Index");
        }


    }
}
