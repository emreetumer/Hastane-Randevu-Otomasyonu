using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proje_odevi.Entities
{
    [Table("Kullanıcılar")]
    public class Kullanici
    {
        [Key]
        public Guid Id  { get; set; }
        [StringLength(50)]
        public string? AdSoyad { get; set; } = null;

        [Required]
        [StringLength(30)]
        public string KullaniciAdi { get; set; }

        [Required]
        [StringLength(100)]
        public string Sifre { get; set; }

        public bool Locked { get; set; } = false;
        public DateTime CreateAt { get; set; } = DateTime.Now;
        [Required]
        [StringLength(50)]
        public string Role { get; set; } = "Kullanici";
            
    }
}
