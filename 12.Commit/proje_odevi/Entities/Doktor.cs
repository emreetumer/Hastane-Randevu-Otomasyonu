
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proje_odevi.Entities
{
    [Table("Doktorlar")]

    public class Doktor
    {
        [Key]
        public Guid ID { get; set; }

        [Required]  
        public string DoktorAdiSoyadi { get; set; }

        [Required]
        public string Alani { get; set; }
    }
}
