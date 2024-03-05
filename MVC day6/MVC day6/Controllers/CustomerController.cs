using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_day6.Models;
using System.Linq;

namespace MVC_day6.Controllers
{
    public class CustomerController : Controller
    {
        ApplicationDbContext context;
        readonly IWebHostEnvironment Environment;
        public CustomerController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            this.context = context;
            Environment = environment;
        }



        // GET: CustomerController
        public ActionResult Index()
        {
            ViewBag.environemt = Environment.EnvironmentName;
            var customers = context.Customers.ToList();
            return View(customers);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            var customer = context.Customers.Find(id);
            return View(customer);
        }

       
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult Create(Customer model)
        {
            if(ModelState.IsValid)
            {
                context.Customers.Add(model);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        
        public ActionResult Edit(int id)
        {
            var customer = context.Customers.Find(id);
            return View(customer);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Customer model)
        {
            var oldobj = context.Customers.Find(id);
            if (ModelState.IsValid)
            {
                if(oldobj !=null)
                {
                    oldobj.Name = model.Name;
                    oldobj.Email = model.Email;
                    oldobj.Gender = model.Gender;
                    oldobj.PhoneNum = model.PhoneNum;
                    context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var customer = context.Customers.Find(id);
            return View(customer);
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Customer model)
        {
            context.Customers.Remove(model);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
