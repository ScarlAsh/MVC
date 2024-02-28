using Day6Demo_SD44.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Day6Demo_SD44.Controllers
{
    public class StudentController : Controller
    {
        StdDbContext context = new StdDbContext ();

        // GET: StudentController
        public ActionResult Index()
        {
            return View(context.Students.Include(s=>s.Department).ToList());
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            return View(context.Students.Include(s => s.Department).FirstOrDefault(s=>s.StudentID == id));
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            ViewBag.allDepartments = context.Departments.ToList();
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        public ActionResult Create(Student Std)
        {
            ViewBag.allDepartments = context.Departments.ToList();

            if(ModelState.IsValid)
            {
                context.Students.Add(Std);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(Std);
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
