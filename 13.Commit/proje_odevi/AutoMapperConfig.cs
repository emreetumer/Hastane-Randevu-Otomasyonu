using AutoMapper;
using proje_odevi.Entities;
using proje_odevi.Models;

namespace proje_odevi
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() 
        {
            CreateMap<Kullanici, KullaniciModel>().ReverseMap();
            CreateMap<Kullanici, OlusturKullaniciModel>().ReverseMap();
            CreateMap<Kullanici, DuzenleKullaniciModel>().ReverseMap();

        }
    }
}
