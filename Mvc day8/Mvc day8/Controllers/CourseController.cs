using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mvc_day8.Models;
using Mvc_day8.Repos;

namespace Mvc_day8.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepo _courseRepo;
        public CourseController(ICourseRepo course)
        {
            _courseRepo = course;
        }
        public ActionResult Index()
        {
            var model = _courseRepo.GetAll();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = _courseRepo.GetById(id);
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Course course)
        {
            if(ModelState.IsValid)
            {
                _courseRepo.Add(course);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(course);
            }
        }
        public ActionResult Edit(int id)
        {
            var model = _courseRepo.GetById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, Course course)
        {
            if(ModelState.IsValid)
            {
                _courseRepo.Update(id , course);
                return RedirectToAction("Index");
            }
            return View(course);
        }

        public ActionResult Delete(int id)
        {
            var model = _courseRepo.GetById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id ,Course course)
        {
           _courseRepo.Delete(id);
           return RedirectToAction("Index");
           
        }
    }
}
