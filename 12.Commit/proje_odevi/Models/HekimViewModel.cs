using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proje_odevi.Models
{
    [Table("Hekimler")]
    public class HekimViewModel
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        public string DoktorAdiSoyadi { get; set; }

        [Required]
        public string Alani { get; set; }
    }
}
