using System.ComponentModel.DataAnnotations;

namespace Day6Demo_SD44.Models
{
    public class Employee
    {
        public int ID { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        [minAge(21)]
        public int Age { get; set; }
    }
}
