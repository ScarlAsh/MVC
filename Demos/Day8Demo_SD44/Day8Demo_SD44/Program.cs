using Day8Demo_SD44.Models;
using Day8Demo_SD44.RepoServices;
using Microsoft.EntityFrameworkCore;

namespace Day8Demo_SD44
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //----------------------- Configure Service - DI Container -------------------------

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //anyone request service of type StdDbContext
            //create & inject StdDbContext with it options
            //
            builder.Services.AddDbContext<StdDbContext>( op =>
                //op.UseSqlServer("Data Source=.;Initial Catalog=RepoDb_SD44;User ID=sa; Password=iti; TrustServerCertificate=true")
                //op.UseSqlServer(builder.Configuration["ConnectionStrings:myConn"])
                op.UseSqlServer(builder.Configuration.GetConnectionString("myConn"))
                );


            //DI Container -->
            //anyone request service of type "IStudentRepository",
            //create & inject obj of class "StudentRepoService" with "Scoped" lifetime

            builder.Services.AddScoped<IStudentRepository, StudentRepoService>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepoService>();


            var app = builder.Build();


            //----------------------- request pipeline -------------------------

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}