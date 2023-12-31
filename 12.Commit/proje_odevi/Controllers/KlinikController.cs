using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using proje_odevi.Entities;
using proje_odevi.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace proje_odevi.Controllers
{
    public class KlinikController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IConfiguration _configuration;
        public KlinikController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IActionResult Klinik()
        {
            var klinikler = _databaseContext.Klinikler.ToList();
            ViewBag.Klinikler = new SelectList(klinikler, nameof(KlinikViewModel.KlinikId), nameof(KlinikViewModel.KlinikAdi));

            var klinikViewModel = new KlinikViewModel
            {
                // Diğer özellikleri burada set edebilirsiniz.
            };

            return View(klinikViewModel);
        }
        [HttpPost]
        public IActionResult KlinikEkle(KlinikViewModel klinikViewModel)
        {
            if (ModelState.IsValid)
            {
                var yeniKlinik = new KlinikViewModel
                {
                    KlinikId = Guid.NewGuid(),
                    KlinikAdi = klinikViewModel.KlinikAdi
                };

                _databaseContext.Klinikler.Add(yeniKlinik);
                _databaseContext.SaveChanges();

                return RedirectToAction("Klinik");
            }

            return View("Klinik", klinikViewModel);
        }
        public IActionResult Klinikler()
        {
            var klinik = _databaseContext.Klinikler.ToList();
            return View(klinik);
        }
       
    }
}
