using HayvanBarinagi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HayvanBarinagi.Controllers
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
        Context context = new Context();

        public IActionResult Hayvanlar()
        {
            var hayvanListesi = context.Hayvanlar.ToList();
            return View(hayvanListesi);
        }

        public IActionResult Privacy()
        {
            ViewBag.Degisken = "Sparky";
            ViewData["Degisken"] = "Kedi";
            TempData["Degisken2"] = 5;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}