using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
namespace SAST_Demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SqlInjectionController : ControllerBase
    {
        [HttpGet("unsafe")]
        public IActionResult UnsafeQuery(string username)
        {
            // ❌ Intentionally vulnerable pattern (redacted)
            string query = "SELECT * FROM Users WHERE Username = '" + username + "'";

            // SAST will flag concatenation + SqlCommand
            using (var connection = new SqlConnection("Server=localhost;Database=TestDB;Trusted_Connection=True;"))
            {
                var command = new SqlCommand(query, connection);  // SAST-Detectable
                // (Execution removed to avoid real vulnerability)
            }

            return Ok("This is a simulated SQL injection vulnerability for SAST testing.");
        }
         public string GetUserData(string password)
        {
            string username = "sqluser";
               // ❌ Intentionally vulnerable pattern (redacted)
            string query = "SELECT * FROM Users WHERE Username = '" + username + "'";

            // SAST will flag concatenation + SqlCommand
            using (var connection = new SqlConnection("Server=localhost;Database=TestDB2;Trusted_Connection=True;"))
            {
                var command = new SqlCommand(query, connection);  // SAST-Detectable
                // (Execution removed to avoid real vulnerability)
            }

            return ("This is a simulated SQL injection vulnerability for SAST.");
        }
    }
}
