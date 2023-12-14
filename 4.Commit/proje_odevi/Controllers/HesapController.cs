using Microsoft.AspNetCore.Mvc;
using proje_odevi.Models;
using System.Reflection;

namespace proje_odevi.Controllers
{
    public class HesapController : Controller
    {
        public IActionResult Giris()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Giris(GirisViewModel model)
        {
            if (ModelState.IsValid) 
            { 
                //giriş işlemleri
            }
            return View(model);
        }
        public IActionResult Kayit()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Kayit(KayitViewModel model)
        {
            if (ModelState.IsValid)
            {
                //kayit işlemleri
            }
            return View(model);
        }
        public IActionResult Profil()
        {
            return View();
        }
    }
}
