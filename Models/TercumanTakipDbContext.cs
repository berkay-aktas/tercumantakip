using Microsoft.EntityFrameworkCore;

namespace TercumanTakipWeb.Models
{
    public class TercumanTakipDbContext : DbContext
    {
        public TercumanTakipDbContext(DbContextOptions<TercumanTakipDbContext> options) : base(options) { }
        public DbSet<isTakipListesi_Telefon> isTakipListesi_Telefon { get; set; }
        public DbSet<isTakipListesi_Yuzyuze> isTakipListesi_Yuzyuze { get; set; }
        public DbSet<isTakipListesi_TopluArama> isTakipListesi_TopluArama { get; set; }
        public DbSet<isTakipListesi_MigrantTV> isTakipListesi_MigrantTV { get; set; }
        public DbSet<isTakipListesi_DisGorev> isTakipListesi_DisGorev { get; set; }
        public DbSet<isTakipListesi_YaziliCeviri> isTakipListesi_YaziliCeviri { get; set; }
        public DbSet<OfisListesi> OfisListesi { get; set; }
        public DbSet<DilListesi> DilListesi { get; set;}
        public DbSet<Users> Users { get; set; }
    }
}
