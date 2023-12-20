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
    }
}
