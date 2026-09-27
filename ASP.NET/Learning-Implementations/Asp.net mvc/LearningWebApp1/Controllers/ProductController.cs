using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using LearningWebApp1.Models;

namespace LearningWebApp1.Controllers
{
    public class ProductController : Controller
    {
        private readonly List<Product> _products = new List<Product> {
            new Product { Id = 1, Name = "Developer Laptop", Price = 1299.99m },
            new Product { Id = 2, Name = "Mechanical Keyboard", Price = 89.50m },
            new Product { Id = 3, Name = "4K Monitor", Price = 349.00m }
        };

        [HttpGet]
        //[Route("products/Details/{id:int}")] // needs strict ../../1 and not ../?id=1(for this remove this line)
        public ActionResult Details(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            return View(product);   
        }
    }
}