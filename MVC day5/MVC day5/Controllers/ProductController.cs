using Microsoft.AspNetCore.Mvc;
using MVC_day5.Models;

namespace MVC_day5.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext context = new();
        public IActionResult Default()
        {
            var defproduct = context.Products.FirstOrDefault();
            return View(defproduct);
        }

        public IActionResult ShowDetails(int id)
        {
            var product = context.Products.Where( i => i.ID == id).FirstOrDefault();
            return View(product);
        }
    }
}
