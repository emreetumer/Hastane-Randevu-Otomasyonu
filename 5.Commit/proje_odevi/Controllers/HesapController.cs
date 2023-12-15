using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NETCore.Encrypt.Extensions;
using proje_odevi.Entities;
using proje_odevi.Models;
using System.Reflection;
using System.Security.Claims;

namespace proje_odevi.Controllers
{
    public class HesapController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IConfiguration _configuration;

        public HesapController(DatabaseContext databaseContext, IConfiguration configuration)
        {
            _databaseContext = databaseContext;
            _configuration = configuration;
        }

        public IActionResult Giris()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Giris(GirisViewModel model)
        {
            if (ModelState.IsValid) 
            {
                string md5Salt = _configuration.GetValue<string>("AppSettings:MD5Salt");
                string saltedPassword = model.Sifre + md5Salt;
                string hashedPassword = saltedPassword.MD5();

                Kullanici kullanici = _databaseContext.Kullanicilar.SingleOrDefault(x => x.KullaniciAdi.ToLower() == model.KullaniciAdi.ToLower() && x.Sifre == hashedPassword);
                if(kullanici != null)
                {
                    if (kullanici.Locked)
                    {
                        ModelState.AddModelError(nameof(model.KullaniciAdi), "Kullanıcı Kilitli");
                        return View(model);
                    }

                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim("Id",kullanici.Id.ToString()));
                    claims.Add(new Claim("AdSoyad",kullanici.AdSoyad ?? string.Empty));
                    claims.Add(new Claim("KullaniciAdi",kullanici.KullaniciAdi));


                    




                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı Adı Veya Şifre Hatalıdır.");
                }
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
                if (_databaseContext.Kullanicilar.Any(x=>x.KullaniciAdi.ToLower()==model.KullaniciAdi.ToLower()))
                {
                    ModelState.AddModelError(nameof(model.KullaniciAdi), "Kullanıcı Adı Daha Önceden Vardır");
                    View(model);
                }
                string md5Salt = _configuration.GetValue<string>("AppSettings:MD5Salt");
                string saltedPassword = model.Sifre + md5Salt;
                string hashedPassword = saltedPassword.MD5();

                Kullanici kullanici = new()
                {
                    KullaniciAdi = model.KullaniciAdi,
                    Sifre = hashedPassword
                };
                _databaseContext.Kullanicilar.Add(kullanici);
                int affectedRowCount = _databaseContext.SaveChanges();
                if(affectedRowCount == 0)
                {
                    ModelState.AddModelError("", "Hata Var");
                }
                else
                {
                    return RedirectToAction(nameof(Giris));
                }
            }
            return View(model);
        }
        public IActionResult Profil()
        {
            return View();
        }
    }
}
