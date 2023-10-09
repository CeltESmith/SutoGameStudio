using Microsoft.AspNetCore.Mvc;
using MVCSutoGameStudio.App.Models;
using System.Diagnostics;

namespace MVCSutoGameStudio.App.Controllers
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

		public IActionResult Catagory()
		{
			return View();
		}

        public IActionResult CreateInfo()
        {
            return View();
        }

        public IActionResult VerifyUser()
        {
            return View();
        }

		public IActionResult Privacy()
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