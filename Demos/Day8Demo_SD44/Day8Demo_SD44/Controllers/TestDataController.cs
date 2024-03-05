using Day8Demo_SD44.Models;
using Day8Demo_SD44.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Day8Demo_SD44.Controllers
{
    public class TestDataController : Controller
    {
        public StdDbContext Context { get; }
        public TestDataController(StdDbContext context)
        {
            Context = context;
        }

        public IActionResult testView(int id)
        {
            //get data from DB

            Student st = Context.Students.Find(id);
            Department dpt = Context.Departments.Find(st.DeptID);

            List<string> CrsLst = new List<string>() { "C#", "DB", "MVC" };
            int num = 30;


            StdWithDeptAndCrsLstViewModel StdViewModel = new StdWithDeptAndCrsLstViewModel()
            {
                StdID =  st.StudentID,
                StdName = st.StdName,
                CourseList = CrsLst,
                CrsHrs = num,
                Dept = dpt
            };

            return View(StdViewModel);
        }
    }
}
