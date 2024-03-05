using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVC_day9.Data;

namespace MVC_day9
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddControllersWithViews();


            //builder.Services.AddAuthentication().AddTwitter(
            //    Op =>
            //    {
            //        Op.ConsumerKey = "TlpnamgxZnMzYm8xenpoRzQ4d1Y6MTpjaQ";
            //        Op.ConsumerSecret = "KljjvxOTz7WcNyfA2QBE7Z-fKut7xF67mnqBjYuosNKW6b9EFI";
            //    });

            builder.Services.AddAuthentication().AddFacebook(
                Op =>
                {
                    Op.ClientId = "1578872899580810";
                    Op.ClientSecret = "3d4a8aef867ae3fe477f46e45fac3746";
                });



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}
