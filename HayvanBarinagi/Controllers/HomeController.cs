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
        Context context = new Context();
        public IActionResult Index()
        {
            var hayvanListesi = context.Hayvanlar.ToList();
            return View(hayvanListesi);
        }
        
        public IActionResult Hayvanlar()
        {
            var hayvanListesi = context.Hayvanlar.ToList();
            return View(hayvanListesi);
        }
        public IActionResult HayvanSil(int Id)
        {
            var SecilenHayvan = context.Hayvanlar.Find(Id);
            context.Hayvanlar.Remove(SecilenHayvan);
            context.SaveChanges();

            return RedirectToAction("Hayvanlar");
        }
        [HttpGet]
        public IActionResult HayvanEkle()
        {

            return View();
        }
        [HttpPost]
        public IActionResult HayvanEkle(Hayvan hayvan)
        {
            var YeniHayvan = new Hayvan
            {
                Adi = hayvan.Adi,
                Yas = hayvan.Yas,
                Cins = hayvan.Cins,
            };
            context.Hayvanlar.Add(YeniHayvan);
            context.SaveChanges();

            return RedirectToAction("Hayvanlar");
        }
        [HttpGet]
        public IActionResult HayvanDuzenle(int Id)
        {

            var SecilenHayvan = context.Hayvanlar.Find(Id);
            return View(SecilenHayvan);
        }
        [HttpPost]
        public IActionResult HayvanDuzenle(Hayvan hayvan)
        {
            var SecilenHayvan = context.Hayvanlar.Find(hayvan.Id);
            SecilenHayvan.Cins = hayvan.Cins;
            SecilenHayvan.Adi = hayvan.Adi;
            SecilenHayvan.Yas = hayvan.Yas;
            context.SaveChanges();

            return RedirectToAction("Hayvanlar");
        }
        public IActionResult Sahiplendirme()
        {
            
            return View();
        }
        public IActionResult Basvuru()
        {

            return View();
        }

        public IActionResult HayvanVerme()
        {

            return View();
        }
        public IActionResult Hakkimizda()
        {

            return View();
        }
        public IActionResult Iletisim()
        {

            return View();
        }
        public IActionResult UyeOl()
        {

            return View();
        }
        public IActionResult GirisYap()
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