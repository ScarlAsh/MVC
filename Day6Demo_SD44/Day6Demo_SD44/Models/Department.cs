using System.ComponentModel.DataAnnotations.Schema;

namespace Day6Demo_SD44.Models
{
    [Table("Department")]
    public class Department
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual IEnumerable<Student>? Students { get; set; }
    }
}
