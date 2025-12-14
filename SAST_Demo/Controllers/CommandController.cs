using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace SAST_Demo.Controllers
{
   
    public class CommandController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string userInput)
        {
            // ❗ VULNERABILITY:
            // User input is concatenated directly into a shell command (CWE-78)
            string command = "/bin/bash";
            string arguments = "-c \"ls " + userInput + "\"";

            var psi = new ProcessStartInfo
            {
                FileName = command,
                Arguments = arguments,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false
            };

            string result;
            try
            {
                using (var process = Process.Start(psi))
                {
                    result = process.StandardOutput.ReadToEnd() +
                             process.StandardError.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                result = "Error: " + ex.Message;
            }

            ViewBag.Output = result;
            return View();
        }
    }
}
