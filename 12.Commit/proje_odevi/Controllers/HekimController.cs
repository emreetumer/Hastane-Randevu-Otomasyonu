using Microsoft.AspNetCore.Mvc;
using proje_odevi.Entities;
using proje_odevi.Models;

namespace proje_odevi.Controllers
{
    public class HekimController : Controller
    {
        private readonly DatabaseContext _databasecontext;

        public HekimController(DatabaseContext databasecontext)
        {
            _databasecontext = databasecontext;
        }

        // Doktor ekleme sayfasını gösteren action
        public IActionResult Hekim()
        {
            return View();
        }

        // Doktor ekleyen action
        [HttpPost]
        public IActionResult DoktorEkle(HekimViewModel HekimViewModel)
        {
            if (ModelState.IsValid)
            {
                var yeniHekim = new HekimViewModel
                {
                    ID = Guid.NewGuid(),
                    DoktorAdiSoyadi = HekimViewModel.DoktorAdiSoyadi,
                    Alani = HekimViewModel.Alani
                };

                _databasecontext.Hekimler.Add(yeniHekim);
                _databasecontext.SaveChanges();

                return RedirectToAction("Hekim"); // Doktorları listeleme sayfasına yönlendirme
            }

            // Eğer model geçerli değilse, aynı sayfayı tekrar göster
            return View(HekimViewModel);
        }

        // Doktorları listeleyen action
        public IActionResult Hekimler()
        {
            var hekim = _databasecontext.Hekimler.ToList();
            return View(hekim);
        }
    }
}
