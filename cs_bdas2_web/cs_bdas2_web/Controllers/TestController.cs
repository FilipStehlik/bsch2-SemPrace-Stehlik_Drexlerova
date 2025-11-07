using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;


namespace bdas2_cs_web.Controllers
{

    public class TestController : Controller
    {
        private readonly IConfiguration _configuration;

        public TestController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            try
            {
                var connectionString = _configuration.GetConnectionString("OracleConnection");

                using (var connection = new OracleConnection(connectionString))
                {
                    connection.Open();

                    ViewBag.Status = "Připojení k databázi funguje!";
                    ViewBag.ServerVersion = connection.ServerVersion;
                    ViewBag.DataSource = connection.DataSource;
                    ViewBag.State = connection.State.ToString();

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Status = "❌ Připojení selhalo";
                ViewBag.Error = ex.Message;
            }

            return View();
        }
    }
}

