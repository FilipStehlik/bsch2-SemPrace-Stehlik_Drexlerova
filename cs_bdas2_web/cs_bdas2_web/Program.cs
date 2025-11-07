using bdas2_cs_web.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace bdas2_cs_web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // zkouska();
            var builder = WebApplication.CreateBuilder(args);

            // Přidání MVC
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
         private static void zkouska()
        {
            var connectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=fei-sql3.upceucebny.cz)(PORT=1521))(CONNECT_DATA=(SID=BDAS)));User Id=st72577;Password=JaJsemDatabaze111;";

            try
            {
                using (var connection = new OracleConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("✅ Připojení na školní Oracle funguje!");

                    var command = connection.CreateCommand();
                    command.CommandText = "SELECT TABLE_NAME FROM USER_TABLES";
                    var reader = command.ExecuteReader();

                    Console.WriteLine("\nTvoje tabulky:");
                    while (reader.Read())
                    {
                        Console.WriteLine($"- {reader.GetString(0)}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Chyba: {ex.Message}");
            }
        }
    }
}