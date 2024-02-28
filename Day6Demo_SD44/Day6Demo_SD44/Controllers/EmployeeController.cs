using Day6Demo_SD44.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day6Demo_SD44.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        //[Route("Emp/main")]
        public IActionResult Index()
        {
            return View(EmployeeList.Employees);
        }

        // GET: Employee/Details/5
        //[Route("Emp/{id:int:min(2)}")]
        public IActionResult Details(int id)
        {
            return View(EmployeeList.Employees.Where(e => e.ID == id).FirstOrDefault());
        }

        //[AllowAnonymous]
        // GET: Employee/Create

        //[Route("Register/Emp")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        //[AcceptVerbs("GET, DELETE")]
        public IActionResult Create(Employee emp)
        {
            if (string.IsNullOrEmpty(emp.Name))
            {
                ModelState.AddModelError("Name", "You must enter a name!");
            }
            if (emp.Age < 18)
            {
                ModelState.AddModelError("Age", "Age must be +18");
            }

            if (ModelState.IsValid)
            {
                EmployeeList.Employees.Add(emp);
                return RedirectToAction("Index");
            }

            return View(emp);
        }
    }
}