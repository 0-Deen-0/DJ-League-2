using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    // Controller for handling home page actions
    public class HomeController : Controller
    {
        // Logger to log any activities or errors within the controller
        private readonly ILogger<HomeController> _logger;

        // Constructor to initialize the logger
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger; // Save the logger to use in the controller
        }

        // GET: Home/Index - Show the home page view
        public IActionResult Index()
        {
            return View(); // Return the Index view
        }

        // GET: Home/Privacy - Show the privacy page view
        public IActionResult Privacy()
        {
            return View(); // Return the Privacy view
        }

        // GET: Home/AboutUs - Show the about us page view
        public IActionResult AboutUs()
        {
            return View(); // Return the AboutUs view
        }

        // GET: Home/Error - Handle error scenarios
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)] // Prevent caching for error pages
        public IActionResult Error()
        {
            // Return the error view with a unique request ID for debugging
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
