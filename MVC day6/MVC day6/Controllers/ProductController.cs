using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_day6.Models;
using MVC_day6.ViewModels;
using System;
using System.Linq;

namespace MVC_day6.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext Context;
        public ProductController(ApplicationDbContext context)
        {
            Context = context;
        }

        public ActionResult Index()
        {
            return View(Context.Products.Include(i => i.Customer).ToList());
        }

        public ActionResult Details(int id)
        {
            var product = Context.Products.Where(i => i.Id == id).Include(i => i.Customer).FirstOrDefault();
            var viewModel = new ProductCustomerViewModel();
            viewModel.Price = product.Price;
            viewModel.CustomerId = product.CustomerId;
            viewModel.CustomerName = product.Customer.Name;
            viewModel.Image = product.Image;
            viewModel.Description = product.Description;
            return View(viewModel);
        }

        public ActionResult Create()
        {
            ViewBag.Customers = Context.Customers.ToList();
            return View(new Product());
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            ViewBag.Customers = Context.Customers.ToList();
            if (ModelState.IsValid)
            {
                try
                {
                    Context.Products.Add(product);
                    Context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("" , ex.Message);
                    return View(product);
                }
            }
           return View(product);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Customers = Context.Customers.ToList();
            return View(Context.Products.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(int id,Product product)
        {
            ViewBag.Customers = Context.Customers.ToList();
            var model = Context.Products.Find(id);
            if (ModelState.IsValid)
            {
                try
                {
                    model!.Price = product.Price;
                    model.Name = product.Name;
                    model.Description = product.Description;
                    model.CustomerId = product.CustomerId;
                    model.Image = product.Image;
                    Context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(product);
                }
            }
            return View(product);
        }

        public ActionResult Delete(int id)
        {
            var product = Context.Products.Where(i => i.Id == id).Include(i => i.Customer).FirstOrDefault();
            var viewModel = new ProductCustomerViewModel();
            viewModel.Price = product!.Price;
            viewModel.CustomerId = product.CustomerId;
            viewModel.CustomerName = product.Customer.Name;
            viewModel.Image = product.Image;
            viewModel.Description = product.Description;
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var model = Context.Products.Where(i => i.Id == id).Include(i => i.Customer).FirstOrDefault();
            try
            {
                Context.Products.Remove(model);
                Context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }
    }
}
