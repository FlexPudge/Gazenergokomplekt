using Gazenergokomplekt.Models;
using Gazenergokomplekt.ViewModels;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;

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
        public IActionResult Products()
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
        public IActionResult BlockModuleBoilers()
        {
            return View();
        }
        public IActionResult Emkosti()
        {
            return View();
        }
        public IActionResult FiltraSeparatory()
        {
            return View();
        }
        public IActionResult GasControlPoints()
        {
            return View();
        }
        public IActionResult GasStation()
        {
            return View();
        }
        public IActionResult PodogrevatelGaza()
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