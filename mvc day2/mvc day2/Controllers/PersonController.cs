using Microsoft.AspNetCore.Mvc;
using mvc_day2.Models;
using System.Security.Cryptography.X509Certificates;

namespace mvc_day2.Controllers
{
	public class PersonController : Controller
	{
		public IActionResult Create()
		{
			return View();
		}
		public IActionResult Details(int Id , string Name  , string Image) 
		{
			Person person  = new Person();
			person.Id = Id;
			person.Name = Name;
			person.Image = Image;
			return View(person);
		}
		public IActionResult Index()
		{
			List<Person> people = new List<Person>()
			{
				new Person() { Id = 1 , Name=  "Ali" , Image = "1.jpg"},
				new Person() { Id = 2 , Name=  "Ahmad" , Image = "2.jpg"},
				new Person() { Id = 3 , Name=  "Omar" , Image = "3.jpg"},
				new Person() { Id = 4 , Name=  "Mohamed" , Image = "4.jpg"},
				new Person() { Id = 5 , Name=  "Yousef" , Image = "5.jpg"},

			};
			return View(people);
		}
	}
}
