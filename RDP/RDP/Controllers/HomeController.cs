using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RDP.Models;
using RDP.Service;

namespace RDP.Controllers
{
    public class HomeController : Controller
    {

        private readonly IRepository _context;

        public HomeController(IRepository context)
        {
            _context = context;
        }

        /// <summary>
        /// Grabs the products from the database and shows them on the page
        /// </summary>
        /// <returns>Task</returns>
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetProducts());
        }

        /// <summary>
        /// Returns the Create view from the Home Index
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,SKU,Name,Description,Price,Quantity")] Products product)
        {
            if(ModelState.IsValid)
            {
                await _context.Add(product);
                return RedirectToAction(nameof(Index));
            }

            return View(product);

        }

        /// <summary>
        /// Grabs the product from the id that you want to edit, brings you to the edit view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(string id)
        {
            var product = await _context.GetProduct(id);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, [Bind("Id,SKU,Name,Description,Price,Quantity")] Products product)
        {
            if(ModelState.IsValid)
            {
                
                await _context.UpdateProduct(product);
                return RedirectToAction(nameof(Index));

            }
            return View(product);
        }

        /// <summary>
        /// Deletes the item using the id and returns the page
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            await _context.Delete(id);

            return RedirectToAction(nameof(Index));
        }



    }
}
