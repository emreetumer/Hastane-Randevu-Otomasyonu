using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration; // IConfiguration için gerekli using direktifi
using proje_odevi.Entities;
using proje_odevi.Models;

namespace proje_odevi.Controllers
{
    public class RandevuController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IConfiguration _configuration;

        public RandevuController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IActionResult Randevu()
        {
            var doktorlar = _databaseContext.Hekimler.ToList();
            ViewBag.Doktorlar = new SelectList(doktorlar, nameof(HekimViewModel.ID), nameof(HekimViewModel.DoktorAdiSoyadi));

            var klinikler = _databaseContext.Klinikler.ToList();
            ViewBag.Klinikler = new SelectList(klinikler, nameof(KlinikViewModel.KlinikAdi), nameof(KlinikViewModel.KlinikAdi));

            var RandevuViewModel = new RandevuViewModel
            {
                
            };

            return View(RandevuViewModel);
        }
         [HttpPost]
        public IActionResult RandevuEkle(RandevuViewModel RandevuViewModel)
        
        {
            if (ModelState.IsValid)
            {
                var yeniRandevu = new RandevuViewModel
                {
                    RandevuId = RandevuViewModel.RandevuId,
                    tarih = RandevuViewModel.tarih,
                    klinik = RandevuViewModel.klinik,
                    SecilenDoktorId=RandevuViewModel.SecilenDoktorId
                    

                      
                };

                _databaseContext.Randevularim.Add(yeniRandevu);
                _databaseContext.SaveChanges();

                return RedirectToAction("Randevu"); // Doktorları listeleme sayfasına yönlendirme
            }

            // Eğer model geçerli değilse, aynı sayfayı tekrar göster
            return View(RandevuViewModel);
        }
        
        // Doktorları listeleyen action
        public IActionResult Randevularim()
        {
            var Randevu = _databaseContext.Randevularim.ToList();
            return View(Randevu);
        }

    }
}
