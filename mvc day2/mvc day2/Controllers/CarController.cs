using Microsoft.AspNetCore.Mvc;
using mvc_day2.Models;

namespace mvc_day2.Controllers
{
	public class CarController : Controller
	{		
		public IActionResult Index()
		{
			var model = CarList.Cars; ;
			return View(model);
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(Car car)
		{
			Car newcar = new Car();
			newcar.Num = car.Num;
			newcar.Model = car.Model;
			newcar.Color = car.Color;
			newcar.Manfacure = car.Manfacure;

			CarList.Cars.Add(newcar);
			return RedirectToAction("Index");
		}

		public IActionResult Select(int Num)
		{
			var selectedcar = CarList.Cars.Where(c => c.Num == Num).FirstOrDefault();
			return View(selectedcar);
		}
		public IActionResult Edit(int Num)
		{
			var selectedcar = CarList.Cars.Where(c => c.Num == Num).FirstOrDefault();
			return View(selectedcar);
		}
		[HttpPost]
		public IActionResult Edit(int Num , Car car)
		{
			var selectedcar = CarList.Cars.Where(c => c.Num == Num).FirstOrDefault();
			selectedcar.Color = car.Color;
			selectedcar.Model = car.Model;
			selectedcar.Manfacure = car.Manfacure;
			return RedirectToAction("Index");
		}
		public IActionResult Delete(int Num)
		{
			var selectedcar = CarList.Cars.Where(c => c.Num == Num).FirstOrDefault();
			CarList.Cars.Remove(selectedcar);
			return RedirectToAction("Index");
		}
	}
}
