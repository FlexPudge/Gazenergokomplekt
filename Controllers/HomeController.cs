using Gazenergokomplekt.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Gazenergokomplekt.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Work()
        {
            return View();
        }
        public IActionResult Inspection()
        {
            return View();
        }
        public IActionResult Installation()
        {
            return View();
        }
        public IActionResult ProjectWork()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}