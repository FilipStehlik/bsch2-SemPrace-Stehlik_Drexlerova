using Microsoft.EntityFrameworkCore;

namespace bdas2_cs_web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Pøidání MVC
            builder.Services.AddControllersWithViews();

            // Registrace DbContext s Oracle
            builder.Services.AddDbContext<OrContext>(options =>
                options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));

            var app = builder.Build();

            // Configure the HTTP request pipeline
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
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