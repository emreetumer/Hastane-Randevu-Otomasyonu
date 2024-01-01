using System.ComponentModel.DataAnnotations;

namespace proje_odevi.Models
{
    public class GirisViewModel
    {
        [Required(ErrorMessage ="Kullanıcı Adı Boş Bırakılmaz")]
        [StringLength(30, ErrorMessage = "30 Karakterden fazla olamaz")]
        public string KullaniciAdi { get; set; }

        //[DataType(DataType.Password)]   
        [Required(ErrorMessage = "Şifre Boş Bırakılmaz")]
        [MinLength(3, ErrorMessage = "3 Karakterden az olamaz")]
        [MaxLength(16, ErrorMessage = "16 Karakterden fazla olamaz")]
        public string Sifre { get; set;}
    }
}
