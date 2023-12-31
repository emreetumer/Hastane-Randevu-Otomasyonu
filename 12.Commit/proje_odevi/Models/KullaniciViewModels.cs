using System.ComponentModel.DataAnnotations;
using System.Drawing;

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

    public class OlusturKullaniciModel
    {
        [Required(ErrorMessage = "Kullanıcı Adı Boş Bırakılmaz")]
        [StringLength(30, ErrorMessage = "30 Karakterden fazla olamaz")]
        public string KullaniciAdi { get; set; }

        [Required]
        [StringLength(50)]
        public string AdSoyad { get; set; }

        public bool Locked { get; set; }



        //[DataType(DataType.Password)]   
        [Required(ErrorMessage = "Şifre Boş Bırakılmaz")]
        [MinLength(3, ErrorMessage = "6 Karakterden az olamaz")]
        [MaxLength(16, ErrorMessage = "16 Karakterden fazla olamaz")]
        public string Sifre { get; set; }

        [Required(ErrorMessage = "Yeniden Şifre Boş Bırakılmaz")]
        [MinLength(3, ErrorMessage = "6 Karakterden az olamaz")]
        [MaxLength(16, ErrorMessage = "16 Karakterden fazla olamaz")]
        [Compare(nameof(Sifre))]
        public string SifreYeniden { get; set; }
        [Required]
        [StringLength(50)]
        public string Role { get; set; } = "Kullanici";
    }
    public class DuzenleKullaniciModel
    {
        [Required(ErrorMessage = "Kullanıcı Adı Boş Bırakılmaz")]
        [StringLength(30, ErrorMessage = "30 Karakterden fazla olamaz")]
        public string KullaniciAdi { get; set; }

        [Required]
        [StringLength(50)]
        public string AdSoyad { get; set; }

        public bool Locked { get; set; }

        [Required]
        [StringLength(50)]
        public string Role { get; set; } = "Kullanici";
    }

}
