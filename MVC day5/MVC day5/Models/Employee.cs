using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_day5.Models
{
	public class Employee
	{
		[Key]
		public int EmpID { get; set; }
		public string? Name { get; set; }
		public string? Password { get; set; }

		public int Salary { get; set; }

		public DateTime Joindate { get; set; } 

		public string? Email { get; set; }

		public int PhoneNum { get; set; }

		[ForeignKey("Department")]
		public int DeptartmentId { get; set; }
		public virtual Department? Deptartment { get; set; }

	}
}
