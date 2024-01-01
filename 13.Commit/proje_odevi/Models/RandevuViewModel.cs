using proje_odevi.Models;
using System.ComponentModel.DataAnnotations;

namespace proje_odevi.Models
{
    public class RandevuViewModel
    {
        [Key]
        public int RandevuId { get; set; } // Birincil anahtar

        public DateTime tarih { get; set; } = DateTime.Today;
        public string klinik { get; set; }
        public List<HekimViewModel> ?Hekimler { get; set; } // Doktorları liste olarak tutuyoruz

        public Guid SecilenDoktorId { get; set; } // Seçilen doktorun ID'sini tutmak için



    }
}
