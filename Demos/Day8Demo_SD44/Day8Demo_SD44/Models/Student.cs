using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Xml.Linq;

namespace Day8Demo_SD44.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public int StudentID { get; set; }

        [Required(ErrorMessage = "maynfa3sh matd7'alsh el esm!!")]
        [MaxLength(30, ErrorMessage = "Too long Name char!!!!!!")]
        [Display(Name = "StudentName")]
        public string StdName { get; set; }

        [Required(ErrorMessage = "U Must Enter Password!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime BirthDate { get; set; }

        [Required]
        [Range(0, 10, ErrorMessage = "Mark have to be within range 0 to 10")]
        public int Mark { get; set; }

        [Required(ErrorMessage = "Enter Email....")]
        [DataType(DataType.EmailAddress)]
        //[RegularExpression(@" ^\w + ([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "U have to re-type ur email...")]
        [Compare("Email", ErrorMessage = "Email Not match!!!")]
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

    public enum Gender { Male, Female }

}
