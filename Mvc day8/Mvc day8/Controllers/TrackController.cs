using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mvc_day8.Models;
using Mvc_day8.Repos;

namespace Mvc_day8.Controllers
{
    [Route("tr")]
    public class TrackController : Controller
    {
        private readonly ITrackRepo _trackRepo;

        public TrackController(ITrackRepo trackRepo)
        {
            _trackRepo = trackRepo;
        }

        [Route("home")]
        public ActionResult Index()
        {
            var model = _trackRepo.GetAll();
            return View(model);
        }

        [Route("showdata/{id:int}")]
        public ActionResult Details(int id)
        {
            var model = _trackRepo.GetById(id);
            return View(model);
        }

        [Route("Addform")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Addtrack")]
        public ActionResult Create(Track track)
        {
            if (ModelState.IsValid)
            {
                _trackRepo.Add(track);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(track);
            }
        }

        [Route("editform/{id:int}")]
        public ActionResult Edit(int id)
        {
            var model = _trackRepo.GetById(id);
            return View(model);
        }

        [HttpPost]
        [Route("edittrack/{id:int}")]
        public ActionResult Edit(int id, Track track)
        {
            if (ModelState.IsValid)
            {
                _trackRepo.Update(id, track);
                return RedirectToAction(nameof(Index));
            }
            return View(track);
        }

        [Route("deleteform/{id:int}")]
        public ActionResult Delete(int id)
        {
            var model = _trackRepo.GetById(id);
            return View(model);
        }

        [HttpPost]
        [Route("deletetrack/{id}")]
        public ActionResult Delete(int id, Track track)
        {
            _trackRepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
