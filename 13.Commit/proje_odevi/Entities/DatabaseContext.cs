using Microsoft.EntityFrameworkCore;
using proje_odevi.Models;

namespace proje_odevi.Entities
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<HekimViewModel> Hekimler { get; set; }
        public DbSet<RandevuViewModel> Randevularim { get; set; }
        public DbSet<KlinikViewModel> Klinikler { get; set; }

    }
}
