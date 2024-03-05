using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mvc_day8.Models;
using Mvc_day8.Repos;

namespace Mvc_day8.Controllers
{
    public class TraineeController : Controller
    {
        private readonly ITraineeRepo _traineeRepo;
        private readonly ICourseRepo _courseRepo;
        private readonly ITrackRepo _trackRepo;
        public TraineeController(ITraineeRepo traineeRepo, ICourseRepo courseRepo, ITrackRepo trackRepo)
        {
            _traineeRepo = traineeRepo;
            _courseRepo = courseRepo;
            _trackRepo = trackRepo;
        }

        public ActionResult Index()
        {
            var model = _traineeRepo.GetAll();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = _traineeRepo.GetById(id);
            return View(model);
        }

        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(_courseRepo.GetAll() , "Id" , "Topic");
            ViewBag.TrackId = new SelectList(_trackRepo.GetAll(), "Id", "Name");
            return View(new Trainee());
        }

        [HttpPost]
        public ActionResult Create(Trainee trainee)
        {
            if (ModelState.IsValid)
            {
                _traineeRepo.Add(trainee);
                return RedirectToAction(nameof(Index));
            }
            else
            {

                ViewBag.CourseId = new SelectList(_courseRepo.GetAll(), "Id", "Topic");
                ViewBag.TrackId = new SelectList(_trackRepo.GetAll(), "Id", "Name");
                return View(trainee);
            }
        }

        public ActionResult Edit(int id)
        {
            ViewBag.CourseId = new SelectList(_courseRepo.GetAll(), "Id", "Topic");
            ViewBag.TrackId = new SelectList(_trackRepo.GetAll(), "Id", "Name");
            var model = _traineeRepo.GetById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, Trainee trainee)
        {
            if (ModelState.IsValid)
            {
                _traineeRepo.Update(id, trainee);
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(_courseRepo.GetAll(), "Id", "Topic");
            ViewBag.TrackId = new SelectList(_trackRepo.GetAll(), "Id", "Name");
            return View(trainee);
        }

        public ActionResult Delete(int id)
        {
            var model = _traineeRepo.GetById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id, Trainee trainee)
        {
            _traineeRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
