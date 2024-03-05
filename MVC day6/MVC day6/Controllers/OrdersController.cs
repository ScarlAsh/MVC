using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_day6.Models;

namespace MVC_day6.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var customers = _context.Customers.ToList();
            ViewBag.Customers = new SelectList(customers, "Id", "Name");
            var model = _context.Orders.Include(o => o.Customer).ToList();
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var order = _context.Orders
                .Include(o => o.Customer)
                .FirstOrDefault(m => m.Id == id);
            if(order == null)
            {
                return View("Error");
            }
            return View(order);
        }

        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Id,Date,TotalPrice,CustomerId")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Name");
            return View(order);
        }

        public IActionResult Edit(int id)
        {
            var order = _context.Orders.Find(id);
            if (order == null)
            {
                return View("Error");
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Name");
            return View(order);
        }

       
        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id,Date,TotalPrice,CustomerId")] Order order)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                     _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
                    {
                        return NotFound();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Name");
            return View(order);
        }

        public IActionResult Delete(int id)
        {
            var order = _context.Orders
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return View("Error");
            }

            return View(order);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var order = _context.Orders.Find(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
            }

            _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Search(int srchid)
        {
            var customers = _context.Customers.ToList();
            ViewBag.Customers = new SelectList(customers , "Id" , "Name" , srchid);

            var model = _context.Orders.Where(i => i.CustomerId == srchid);
            return View("Index" , model);
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
