using Microsoft.EntityFrameworkCore;

namespace MVC_day5.Models
{
	public class ApplicationDbContext : DbContext
	{
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

		public DbSet<Product> Products { get; set; }
        public ApplicationDbContext() : base()
        {
            
        }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source = .;Initial Catalog =day5db;User ID=ITIStud; Password=123 ;Integrated security = true;TrustServerCertificate=true;");
			base.OnConfiguring(optionsBuilder);
		}

	}
}
