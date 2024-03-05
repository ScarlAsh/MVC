using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mvc_day8.Models
{
    [Table("Tracks")]
    public class Track
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "you must enter the track name ..")]
        public string Name { get; set; }

        [MinLength(10 , ErrorMessage = "Description should be 10 characters or more") , MaxLength(20 , ErrorMessage ="Description shouldn't be more than 20 characters")]
        public string Description { get; set; }
    }
}