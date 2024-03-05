using System.ComponentModel.DataAnnotations;

namespace Mvc_day8.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="enter a topic..")]
        public string Topic {  get; set; }
        [Range(0,100)]
        public int Grade { get; set; }
    }
}