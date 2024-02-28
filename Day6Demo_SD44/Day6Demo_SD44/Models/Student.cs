using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Day6Demo_SD44.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public int StudentID { get; set; }

        [Required(ErrorMessage = "U Should Enter A Name!!!")]
        [MaxLength(30, ErrorMessage = "Too Long Name!!!!")]
        [Display(Name="StudentName")]
        public string Name { get; set; }

        [Required(ErrorMessage = "U Have To Specify A Password...")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime BirthDate { get; set; }

        [Required]
        [Range(0, 10, ErrorMessage = "Mark Should be within Range 0 to 10...")]
        public int Mark { get; set; }

        [Required(ErrorMessage = "Enter An Email...")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Enter A Valid Email Address!!")]
        //[RegularExpression(@" ^\w + ([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]

        [UniqueEmail]
        public string Email { get; set; }

        [Required(ErrorMessage = "You have To Re-Type Ur Email...")]
        [Compare("Email", ErrorMessage = "Email Doesn't Match!!!!!")]
        public string ConfirmEmail { get; set; }

        [Required]
        [EnumDataType(typeof(Gender))]
        public Gender gender { get; set; }

        public int Age { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }

        public string Address { get; set; }

        public bool IsActive { get; set; }

        [ForeignKey("Department")]
        public int DeptID { get; set; }

        public virtual Department? Department { get; set; }
    }

    public enum Gender
    { Male , Female }
}
