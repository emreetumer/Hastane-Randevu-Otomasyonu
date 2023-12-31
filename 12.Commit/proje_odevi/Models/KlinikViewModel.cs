using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proje_odevi.Models
{
    [Table("Klinikler")]
    public class KlinikViewModel
    {
        [Key]
        public Guid KlinikId { get; set; }
        public string KlinikAdi { get; set;}

    }
}
