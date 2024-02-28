using Microsoft.EntityFrameworkCore;
using Day6Demo_SD44.Models;

namespace Day6Demo_SD44.Models
{
    public class StdDbContext:DbContext
    {
        public StdDbContext():base()
        {
            
        }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=StdDpt_SD44;Integrated Security=True; TrustServerCertificate=true");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Day6Demo_SD44.Models.Employee> Employee { get; set; } = default!;
    }
}
