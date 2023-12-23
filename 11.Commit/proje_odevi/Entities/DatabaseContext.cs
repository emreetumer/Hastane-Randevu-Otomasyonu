using Microsoft.EntityFrameworkCore;

namespace proje_odevi.Entities
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Kullanici> Kullanicilar { get; set; }
    }
}
