using Microsoft.AspNetCore.Mvc;

namespace SAST_Demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class XSSController : ControllerBase
    {
        [HttpGet("reflect")]
        public ContentResult Reflect(string input)
        {
            // ❌ Direct output without encoding (pattern only)
            return new ContentResult 
            {
                Content = $"<div>User input: {input}</div>",  // SAST flags missing encoding
                ContentType = "text/html"
            };
        }
    }
}
