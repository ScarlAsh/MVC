using Day8Demo_SD44.Models;

namespace Day8Demo_SD44.ViewModels
{
    public class StdWithDeptAndCrsLstViewModel
    {
        public int StdID { get; set; }
        public string StdName { get; set; }
        public List<string> CourseList { get; set; }
        public int CrsHrs { get; set; }
        public Department Dept { get; set; }
    }
}
