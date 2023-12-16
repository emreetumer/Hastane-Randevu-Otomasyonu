using System.ComponentModel.DataAnnotations;

namespace proje_odevi.Models
{
    public class KayitViewModel
    {
        [Required(ErrorMessage = "Kullanıcı Adı Boş Bırakılmaz")]
        [StringLength(30, ErrorMessage = "30 Karakterden fazla olamaz")]
        public string KullaniciAdi { get; set; }

        //[DataType(DataType.Password)]   
        [Required(ErrorMessage = "Şifre Boş Bırakılmaz")]
        [MinLength(6, ErrorMessage = "6 Karakterden az olamaz")]
        [MaxLength(16, ErrorMessage = "16 Karakterden fazla olamaz")]
        public string Sifre { get; set; }

        [Required(ErrorMessage = "Yeniden Şifre Boş Bırakılmaz")]
        [MinLength(6, ErrorMessage = "6 Karakterden az olamaz")]
        [MaxLength(16, ErrorMessage = "16 Karakterden fazla olamaz")]
        [Compare(nameof (Sifre))]
        public string SifreYeniden { get; set; }
    }
}
