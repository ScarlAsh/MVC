using System.ComponentModel.DataAnnotations;

namespace MVC_day5.Models
{
	public class Department
	{
		[Key]
		public int DeptID { set; get; }
		public string? Name { set; get; }
		public string? Description { get; set; }
		public virtual List<Employee> Employees { get; set; } = new();
	}
}