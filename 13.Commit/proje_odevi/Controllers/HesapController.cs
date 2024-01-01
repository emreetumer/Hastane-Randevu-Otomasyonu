using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NETCore.Encrypt.Extensions;
using proje_odevi.Entities;
using proje_odevi.Models;
using System.ComponentModel.DataAnnotations;
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
                string hashedPassword = DoMD5HashedString(model.Sifre);

                Kullanici kullanici = _databaseContext.Kullanicilar.SingleOrDefault(x => x.KullaniciAdi.ToLower() == model.KullaniciAdi.ToLower() && x.Sifre == hashedPassword);
                if (kullanici != null)
                {
                    if (kullanici.Locked)
                    {
                        ModelState.AddModelError(nameof(model.KullaniciAdi), "Kullanıcı Kilitli");
                        return View(model);
                    }

                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, kullanici.Id.ToString()));
                    claims.Add(new Claim(ClaimTypes.Name, kullanici.AdSoyad ?? string.Empty));
                    claims.Add(new Claim(ClaimTypes.Role, kullanici.Role));
                    claims.Add(new Claim("KullaniciAdi", kullanici.KullaniciAdi));

                    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı Adı Veya Şifre Hatalıdır.");
                }
            }
            return View(model);
        }

        private string DoMD5HashedString(string b)
        {
            string md5Salt = _configuration.GetValue<string>("AppSettings:MD5Salt");
            string salted = b + md5Salt;
            string hashed = salted.MD5();
            return hashed;
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
                string hashedPassword = DoMD5HashedString(model.Sifre);

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
            ProfileBilgiYukle();
            return View();
        }

        private void ProfileBilgiYukle()
        {
            Guid userid = new(User.FindFirstValue(ClaimTypes.NameIdentifier));
            Kullanici user = _databaseContext.Kullanicilar.SingleOrDefault(x => x.Id == userid);
            ViewData["AdSoyad"] = user.AdSoyad;
            ViewData["ProfilResmi"] = user.ProfilResmiDosyaAdi;
        }

        [HttpPost]
 public IActionResult ProfilChangeAdSoyad([Required] [StringLength(50)]string? AdSoyad)
 {

                if (ModelState.IsValid)
                 {
                    Guid userid = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                    Kullanici user=_databaseContext.Kullanicilar.SingleOrDefault(x=>x.Id== userid);
                    user.AdSoyad = AdSoyad;
                    _databaseContext.SaveChanges();
                    return RedirectToAction(nameof(Profil));
                 }
            ProfileBilgiYukle();
            return View("Profil");
 }
        [HttpPost]
        public IActionResult ProfilChangeSifre([Required(ErrorMessage ="Boş Bırakmayınız")][MinLength(3,ErrorMessage ="En az 6 karakter olmalı")] [MaxLength(16,ErrorMessage ="En fazla 16 karakter olmalı")] string Sifre)
        {

            if (ModelState.IsValid)
            {
                Guid userid = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                Kullanici user = _databaseContext.Kullanicilar.SingleOrDefault(x => x.Id == userid);
                string hashedPassword = DoMD5HashedString(Sifre);
                user.Sifre = hashedPassword;
                _databaseContext.SaveChanges();
                ViewData["Sonuc"] = "ŞifreDeğiştirildi";
            }
            ProfileBilgiYukle();
            return View("Profil");
        }
        [HttpPost]
        public IActionResult ProfilChangeResim([Required] IFormFile file)
        {

            if (ModelState.IsValid)
            {
                Guid userid = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                Kullanici user = _databaseContext.Kullanicilar.SingleOrDefault(x => x.Id == userid);
                string fileName = $"p_{userid}.jpg";
                Stream stream = new FileStream($"wwwroot/uploads/{fileName}", FileMode.OpenOrCreate);
                file.CopyTo(stream);
                stream.Close();
                stream.Dispose();
                user.ProfilResmiDosyaAdi = fileName;
                _databaseContext.SaveChanges();
                return RedirectToAction(nameof(Profil));
            }
            ProfileBilgiYukle();
            return View("Profil");
        }
        public IActionResult Cikis()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Giris));
        }
    }
}
