using Microsoft.EntityFrameworkCore;

namespace Day8Demo_SD44.Models
{
    public class StdDbContext:DbContext
    {
        //Request service oftype DbContextOptions<StdDbContext> to be injected in ctor
        public StdDbContext(DbContextOptions<StdDbContext> options):base(options)
        {
            
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Department> Departments { get; set; }

    }
}
