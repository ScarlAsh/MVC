using Day8Demo_SD44.Models;
using Day8Demo_SD44.RepoServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day8Demo_SD44.Controllers
{
    //..../Student/Index
    //..../Student/Details/3
    //.....


    public class StudentController : Controller
    {
        //StudentRepoService StudentRepoService = new StudentRepoService()

        //request service of type "IStudentRepository", create & inject obj of class "StudentRepoService"
        //and service of type "IDepartmentRepository", create & inject obj of class "DepartmentRepoService"

        public IStudentRepository StudentRepository { get; }
        public IDepartmentRepository DepartmentRepository { get; }

        public StudentController(IStudentRepository studentRepository, IDepartmentRepository departmentRepository)
        {
            StudentRepository = studentRepository;
            DepartmentRepository = departmentRepository;
        }

        // GET: StudentController
        public ActionResult Index()
        {
            //return View(StudentRepository.GetAll());
            return PartialView(StudentRepository.GetAll()); //render view without layout
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            return View(StudentRepository.GetDetails(id));
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            ViewBag.AllDepts = DepartmentRepository.GetAll();
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        public ActionResult Create(Student Std)
        {
            ViewBag.AllDepts = DepartmentRepository.GetAll();

            if (ModelState.IsValid)
            {
                try
                {
                    StudentRepository.InsertStd(Std);
                    return RedirectToAction(nameof(Index));
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(Std);
                }
            }
            return View(Std);
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.AllDepts = DepartmentRepository.GetAll();

            return View(StudentRepository.GetDetails(id));
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            ViewBag.AllDepts = DepartmentRepository.GetAll();

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
