namespace FisrtMVCcore_SD_44
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();   //Middleware: Generate Routing Table

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "otherRoute",
                pattern: "test",
                defaults: new { controller = "Employee", action = "testFun"} );

            app.MapControllerRoute(
               name: "myRoute",
               pattern: "MVC/{*a}",
               defaults: new { controller = "Home", action = "Privacy" });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}