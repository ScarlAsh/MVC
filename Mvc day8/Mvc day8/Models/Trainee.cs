using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mvc_day8.Models
{
    [Table("Trainees")]
    public class Trainee
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="You Must enter your name...")]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage ="please enter your email address...")]
        public string Email { get; set; }

        public Gender Gender { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string MobileNo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd-MM-yyyy}")]
        public DateTime BirthDate {  get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }

        [ForeignKey("Track")]
        public int TrackId { get; set; }

        public virtual Course Course { get; set; }

        public virtual Track Track { get; set; }
    }
    
    public enum Gender
    {
        Male ,
        Female
    }
}
