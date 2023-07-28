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

        public IActionResult Hayvanlar()
        {
            List<Hayvan> hayvanlar = new List<Hayvan> {
                new Hayvan {Id = 1,Adi="Sparky",Yas=7,Cins="Köpek"},
                new Hayvan {Id = 2,Adi="Snowball",Yas=4,Cins="Kedi"},
                new Hayvan {Id = 3,Adi="Sedir",Yas=12,Cins="Kaplumbağa"}
            };
            HayvanListeModeli hayvanListeModeli = new HayvanListeModeli {hayvanListModel=hayvanlar};
            return View(hayvanListeModeli);
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