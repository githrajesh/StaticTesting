using Microsoft.AspNetCore.Mvc;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Data.SqlClient;
namespace SAST_Demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InsecureDeserializationController : ControllerBase
    {
        [HttpPost("deserialize")]
        public IActionResult Deserialize([FromBody] string base64)
        {
            // ❌ Intentionally vulnerable pattern for SAST testing
#pragma warning disable SYSLIB0011 // Type or member is obsolete
            var formatter = new BinaryFormatter();  // Deprecated & insecure
            var bytes = Convert.FromBase64String(base64);
            var obj = formatter.Deserialize(new MemoryStream(bytes));
#pragma warning restore SYSLIB0011

            return Ok("Simulated insecure deserialization pattern for SAST tools.");
        }
    }
}
