using Microsoft.AspNetCore.Mvc;

namespace SAST_Demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BrokenAuthController : ControllerBase
    {
        // ❌ Hardcoded weak password (redacted)
        private const string hardcodedPassword = "password123";

        [HttpPost("login")]
        public IActionResult Login(string username, string password)
        {
            // ❌ Authentication bypass pattern
            if (password == hardcodedPassword)  // SAST will flag hardcoded secret
            {
                return Ok("Simulated authentication bypass.");
            }

            return Unauthorized();
        }
    }
}
