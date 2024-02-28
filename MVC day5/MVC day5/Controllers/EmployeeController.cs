using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_day5.Models;

namespace MVC_day5.Controllers
{
	public class EmployeeController : Controller
	{
		private readonly ApplicationDbContext _context = new(); 
		public IActionResult Index()
		{
			var model = _context.Employees.Include(d => d.Deptartment).ToList();
            var Depts = _context.Departments.ToList();
            ViewBag.Departments = new SelectList(Depts, "DeptID", "Name");
            return View(model);
		}
		public IActionResult Create()
		{
			var Depts = _context.Departments.ToList();
			ViewBag.Departments = new SelectList(Depts , "DeptID" , "Name");
			return View(new Employee());
		}
		[HttpPost]
		public IActionResult Create(Employee model)
		{
			Employee newemp = new();
			newemp.Name = model.Name;
			newemp.Salary = model.Salary;
			newemp.Joindate = model.Joindate;
			newemp.Password = model.Password;
			newemp.Email = model.Email;
			newemp.PhoneNum = model.PhoneNum;
			newemp.DeptartmentId = model.DeptartmentId;

			if (ModelState.IsValid)
			{
				_context.Employees.Add(newemp);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			var Depts = _context.Departments.ToList();
			ViewBag.Departments = new SelectList(Depts, "DeptID", "Name");
			return View(newemp);
		}
		public IActionResult Edit(int id)
		{
            var Depts = _context.Departments.ToList();
            ViewBag.Departments = new SelectList(Depts, "DeptID", "Name");
            var model = _context.Employees.Where(i => i.EmpID == id).FirstOrDefault();
			return View(model);
		}
		[HttpPost]
		public IActionResult Edit(int id , Employee model)
		{
			var oldemp = _context.Employees.Where(i => i.EmpID == id).FirstOrDefault();
			if(ModelState.IsValid)
			{
                oldemp.Name = model.Name;
                oldemp.Salary = model.Salary;
                oldemp.Joindate = model.Joindate;
                oldemp.Password = model.Password;
                oldemp.Email = model.Email;
                oldemp.PhoneNum = model.PhoneNum;
                oldemp.DeptartmentId = model.DeptartmentId;
				_context.SaveChanges();
				return RedirectToAction("Index");
            }
            var Depts = _context.Departments.ToList();
            ViewBag.Departments = new SelectList(Depts, "DeptID", "Name");
            return View(model);
		}
		public IActionResult Details (int id)
		{
			var model = _context.Employees.Find(id);
			return View(model);
		}
		[HttpGet]
		public IActionResult Delete(int id)
		{
            var model = _context.Employees.Find(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id , Employee oldemp)
        {
            var model = _context.Employees.Find(id);
			_context.Employees.Remove(model);
			_context.SaveChanges();
			return RedirectToAction("index");
        }

		[HttpPost]
		public IActionResult Search(IFormCollection collection)
		{
			int srchid = int.Parse(collection["srchid"]);
            var model = _context.Employees.Where(i => i.DeptartmentId == srchid).ToList();
            var Depts = _context.Departments.ToList();
            ViewBag.Departments = new SelectList(Depts, "DeptID", "Name" , srchid);
            return View("Index" , model);
		}
    }
}
