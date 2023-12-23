using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using proje_odevi.Entities;
using proje_odevi.Models;

namespace proje_odevi.Controllers
{
    public class KullaniciController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        public KullaniciController(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            List<KullaniciModel> kullanicilar=_databaseContext.Kullanicilar.ToList().Select(x=>_mapper.Map<KullaniciModel>(x)).ToList();
            return View(kullanicilar);
        }
        public IActionResult Olustur()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Olustur(OlusturKullaniciModel model)
        {
            if(ModelState.IsValid)
            {
                if (_databaseContext.Kullanicilar.Any(x => x.KullaniciAdi.ToLower() == model.KullaniciAdi.ToLower()))
                {
                    ModelState.AddModelError(nameof(model.KullaniciAdi), "Kullanıcı adı mevcut");
                    return View(model);
                }
                Kullanici user = _mapper.Map<Kullanici>(model);
                _databaseContext.Kullanicilar.Add(user);
                _databaseContext.SaveChanges();
                return RedirectToAction(nameof(Index));

            }
            return View(model);
        }

        public IActionResult Duzenle(Guid id)
        {
            Kullanici user = _databaseContext.Kullanicilar.Find(id);
            DuzenleKullaniciModel model = _mapper.Map<DuzenleKullaniciModel>(user);
            return View(model);
        }
        [HttpPost]
        public IActionResult Duzenle(Guid id, DuzenleKullaniciModel model)
        {
            if (ModelState.IsValid)
            {

                if (_databaseContext.Kullanicilar.Any(x => x.KullaniciAdi.ToLower() == model.KullaniciAdi.ToLower() && x.Id != id))
                {
                    ModelState.AddModelError(nameof(model.KullaniciAdi), "Kullanıcı adı mevcut");
                    return View(model);
                }

                Kullanici user = _databaseContext.Kullanicilar.Find(id);
                _mapper.Map(model, user);
                _databaseContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}
