using FisrtMVCcore_SD_44.Models;
using Microsoft.AspNetCore.Mvc;

namespace FisrtMVCcore_SD_44.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult getAll()
        {
            ViewBag.Emps = EmployeeList.Employees;
            return View();
        }

        public IActionResult getbyId(int id)
        {
            ViewBag.selectedEmp = EmployeeList.Employees.Where(e=>e.Id == id).FirstOrDefault();
            return View();
        }

        public IActionResult Delete(int id)
        {
            EmployeeList.Employees
                .Remove(EmployeeList.Employees.Where(e => e.Id == id).FirstOrDefault());

            return RedirectToAction("getAll");
            
            //return View("getAll");  // viewbag of EmployeeLst will be null

            //return getAll();  //as if we take getAll function code and put it here, delete view will not be found
        }

        public IActionResult Edit(int id)
        {
            ViewBag.selectedEmp = EmployeeList.Employees.Where(e => e.Id == id).FirstOrDefault();
            return View();
        }
        //public IActionResult EditSave(int id, string name, int Age, string Email)
        //{
        //    Employee EditedEmp = EmployeeList.Employees.Where(e => e.Id == id).FirstOrDefault();

        //    EditedEmp.Name = name;
        //    EditedEmp.Age = Age;
        //    EditedEmp.Email = Email;

        //    return RedirectToAction("getAll");
        //}

        //public IActionResult EditSave(IFormCollection collection)
        //{
        //    Employee EditedEmp = EmployeeList.Employees
        //        .Where(e => e.Id == int.Parse(collection["id"])).FirstOrDefault();

        //    EditedEmp.Name = collection["name"];
        //    EditedEmp.Age = int.Parse(collection["Age"]);
        //    EditedEmp.Email = collection["Email"];

        //    return RedirectToAction("getAll");
        //}

        public IActionResult EditSave([Bind(include: "Id, Name")] Employee Emp)
        {
            Employee EditedEmp = EmployeeList.Employees.Where(e => e.Id == Emp.Id).FirstOrDefault();

            EditedEmp.Name = Emp.Name;
            EditedEmp.Age = Emp.Age;
            EditedEmp.Email = Emp.Email;

            return RedirectToAction("getAll");
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult CreateSave(int id, string name, int Age, string Email)
        {
            Employee newEmp = new Employee ()
            { Id = id, Name = name, Age = Age, Email = Email };

            EmployeeList.Employees.Add(newEmp);

            return RedirectToAction("getAll");
        }
        ///////////////////////////////////////////////////////////////////////////////////

        //public IActionResult testFun4()
        //{
        //    ViewData["msg"] = "Hello View Data";

        //    ViewData["BookNames"] = new List<string>(){ "C#", "DB", "MVC"};


        //    ViewBag.myKey1 = "Hello ViewBag :))";

        //    ViewBag.myKey2 = new List<string>() { "C++", "API", "Grpc" };

        //    return View(); 
        //}

        //public string testFun()
        //{
        //    return "Hello in my First MVCApp.......";
        //}

        ////Action Return Types: 
        ////1. "Content" String
        ////2. Json
        ////3. Void
        ////4. View
        ////5. File
        ////6. NotFound

        //public ContentResult testContent()
        //{
        //    //Declare Object
        //    //set Data
        //    //return

        //    //ContentResult ContentResultObj = new ContentResult();
        //    //ContentResultObj.Content = "Hello in my First MVCApp.......";
        //    //return ContentResultObj;

        //    return Content("Hello in my First MVCApp.......");
        //}

        //public JsonResult testJson()
        //{
        //    //JsonResult JsonResultObj = new JsonResult(new { ID = 1, Name = "Mohamed"});
        //    //return JsonResultObj;

        //    return Json(new { ID = 1, Name = "Mohamed" });
        //}

        //public ViewResult testView()
        //{
        //    //ViewResult ViewResultObj = new ViewResult();
        //    //ViewResultObj.ViewName = "myView";
        //    //return ViewResultObj;

        //    return View("myView");
        //}

        //public IActionResult testFun3(int value)
        //{
        //    if (value >= 0)
        //    {
        //        ViewResult ViewResultObj = new ViewResult();
        //        ViewResultObj.ViewName = "myView";
        //        return ViewResultObj;
        //    }
        //    else
        //    {
        //        ContentResult ContentResultObj = new ContentResult();
        //        ContentResultObj.Content = "Sorry, Negative Number!!!";
        //        return ContentResultObj;
        //    }
        //}
    }
}
