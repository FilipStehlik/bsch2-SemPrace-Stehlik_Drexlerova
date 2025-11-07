//using Microsoft.EntityFrameworkCore;

//namespace TvojProjekt.Data
//{
//    public class OrContext : DbContext
//    {
//        public OrContext(DbContextOptions<OrContext> options)
//            : base(options)
//        {
//        }

//        // DbSety pro všechny tabulky
//        public DbSet<Vojak> Vojaci { get; set; }
//        public DbSet<Utvar> Utvary { get; set; }
//        public DbSet<Hodnost> Hodnosti { get; set; }
//        public DbSet<StavPohotovosti> StavyPohotovosti { get; set; }
//        public DbSet<Dovolenka> Dovolenky { get; set; }
//        public DbSet<Mise> Mise { get; set; }
//        public DbSet<Skoleni> Skoleni { get; set; }
//        public DbSet<Technika> Technika { get; set; }
//        public DbSet<Letoun> Letouny { get; set; }
//        public DbSet<Vozidlo> Vozidla { get; set; }
//        public DbSet<Zbran> Zbrane { get; set; }
//        public DbSet<Vyznamenani> Vyznamenani { get; set; }
//        public DbSet<UcastMise> UcastiMisi { get; set; }
//        public DbSet<RevizeSkoleni> RevizeSkoleni { get; set; }
//        public DbSet<NasazeniTechniky> NasazeniTechniky { get; set; }
//        public DbSet<PrideleniZbrane> PrideleniZbrani { get; set; }
//        public DbSet<UdeleniVyznamenani> UdeleniVyznamenani { get; set; }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            base.OnModelCreating(modelBuilder);

//            // Konfigurace názvù tabulek (Oracle upper case)
//            modelBuilder.Entity<Vojak>().ToTable("VOJACI");
//            modelBuilder.Entity<Utvar>().ToTable("UTVARY");
//            modelBuilder.Entity<Hodnost>().ToTable("HODNOSTI");
//            // ... atd pro ostatní entity

//            // Složené primární klíèe
//            modelBuilder.Entity<UcastMise>()
//                .HasKey(u => new { u.IdVojak, u.IdMise });

//            modelBuilder.Entity<RevizeSkoleni>()
//                .HasKey(r => new { r.IdVojak, r.IdSkoleni });

//            modelBuilder.Entity<NasazeniTechniky>()
//                .HasKey(n => new { n.IdMise, n.IdTechnika });

//            modelBuilder.Entity<PrideleniZbrane>()
//                .HasKey(p => new { p.IdVojak, p.IdZbran });

//            modelBuilder.Entity<UdeleniVyznamenani>()
//                .HasKey(u => new { u.IdVojak, u.IdVyznamenani });

//            // Vztahy a další konfigurace...
//        }
//    }
//}
using Microsoft.EntityFrameworkCore;

namespace bdas2_cs_web.Models
{
    using Microsoft.EntityFrameworkCore;

    public class OrContext : DbContext
    {
        public OrContext(DbContextOptions<OrContext> options)
            : base(options)
        {
        }

        // Zde pøidáš své DbSety pro tabulky
        // public DbSet<YourEntity> YourTable { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Konfigurace pro Oracle
        }
    }

}
