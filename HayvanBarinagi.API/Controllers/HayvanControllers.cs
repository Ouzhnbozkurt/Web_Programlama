using HayvanBarinagi.Models;
using HayvanBarinagi.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HayvanBarinagi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HayvanControllers : ControllerBase
    {
        private readonly HayvanRepository _hayvanRepo;
        public HayvanControllers(HayvanRepository repo)
        {
            _hayvanRepo = repo;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var TumHayvanlar = _hayvanRepo.Queryable().ToList();
            if(TumHayvanlar!=null)
            {
                return Ok(TumHayvanlar);
            }
            return BadRequest("Hayvan bulamadı.");
        }
        [HttpPost]
        public IActionResult Create([FromBody] Hayvan hayvan)
        {
            var YeniHayvan = new Hayvan
            {
                Adi = hayvan.Adi,
                Yas = hayvan.Yas,
                Cins = hayvan.Cins,
            };
            _hayvanRepo.Add(YeniHayvan);
            _hayvanRepo.SaveChanges();

            return Ok(YeniHayvan);
        }

        // hayvanın adıyla bulacak linq sorgusu
        [HttpPut]
        public IActionResult Update([FromBody] Hayvan hayvan)
        {
            var SecilenHayvan = _hayvanRepo.Queryable().Where(x => x.Adi == hayvan.Adi).FirstOrDefault();

            if (SecilenHayvan != null)
            {
                SecilenHayvan.Cins = hayvan.Cins;
                SecilenHayvan.Adi = hayvan.Adi;
                SecilenHayvan.Yas = hayvan.Yas;
                _hayvanRepo.SaveChanges();
                return Ok(SecilenHayvan);
            }
            else
            {
                return BadRequest("Hayvan bulunamadı.");
            }
        }

        // Hayvanın id sine göre veritabanından silme işlemi
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var SecilenHayvan = _hayvanRepo.Queryable().Where(x => x.Id == id).FirstOrDefault();
            if (SecilenHayvan != null)
            {
                _hayvanRepo.Delete(SecilenHayvan);
                _hayvanRepo.SaveChanges();
                return Ok("Hayvan kaldırıldı.");
            }
            else
            {
                return BadRequest("Hayvan bulunamadı.");
            }
        }

    }
}
