using Microsoft.AspNetCore.Mvc;

namespace SAST_Demo.Controllers
{
    public class FileController : Controller
    {
   
        private readonly string basePath = "/var/www/files"; // Example folder

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string fileName)
        {
            // ❗ VULNERABILITY: User input used directly to build file path (CWE-22)
            string fullPath = Path.Combine(basePath, fileName);

            string fileContents;
            try
            {
                fileContents = System.IO.File.ReadAllText(fullPath);
            }
            catch (Exception ex)
            {
                fileContents = "Error: " + ex.Message;
            }

            ViewBag.FileContents = fileContents;
            ViewBag.RequestedPath = fullPath;

            return View();
        }
    }
}
