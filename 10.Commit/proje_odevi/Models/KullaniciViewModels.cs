using System.ComponentModel.DataAnnotations;

namespace proje_odevi.Models
{
    public class KullaniciModel
    {

        public Guid Id { get; set; }
        public string? AdSoyad { get; set; } = null;
        public string KullaniciAdi { get; set; }
        public bool Locked { get; set; } = false;
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public string ProfilResmiDosyaAdi { get; set; } = "noimage.jpg";
        public string Role { get; set; } = "Kullanici";
    }
}
