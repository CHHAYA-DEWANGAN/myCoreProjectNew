// Controllers/ProductController.cs
using Microsoft.AspNetCore.Mvc;
using myCoreProjectNew.DAL;
using myCoreProjectNew.Models;
using System.Collections.Generic;
using myCoreProjectNew;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace myCoreProjectNew.Controllers
{
    public class ProductController : Controller
    {
       private readonly myCoreProjectNewContext _context;

        public ProductController(myCoreProjectNewContext context)
        {
            _context = context;
        }
        private static List<Product> _products = new List<Product>();

        public IActionResult Index()
        {
            var products = _context.Products.ToList();

            if (products == null || products.Count == 0)
            {
                return NotFound("No products found");
            }
            // return Ok(products);
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            _context.Products.AddRange(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                return NotFound(); // Return 404 Not Found if the product is not found
            }
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product updatedProduct)
        {
            try
            {
                var product = await _context.Products.FindAsync(updatedProduct.Id);
                if (product == null)
                {
                    return NotFound(); // Return 404 Not Found if the product is not found
                }
                product.Name = updatedProduct.Name;
                product.Price = updatedProduct.Price;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(500); // Return 500 Internal Server Error
            }
            return RedirectToAction("Index");
            // return NoContent(); // Return 204 No Content if the update was successful
        }
    

        [HttpGet]
        public  async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var product = await _context.Products.FindAsync(id);
                if (product == null)
                {
                    return NotFound(); // Return 404 Not Found if the product is not found
                }
                _context.Products.Remove(product);
                    await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(500); // Return 500 Internal Server Error
            }

            // return NoContent();
            return RedirectToAction("Index");
        }
    }
}
