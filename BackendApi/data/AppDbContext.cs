using Microsoft.EntityFrameworkCore;
using BackendApi.Models;

namespace BackendApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Peminjaman> Peminjaman { get; set; }
        public DbSet<StatusHistory> StatusHistory { get; set; }
        public DbSet<Ruangan> Ruangan { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data Ruangan
            modelBuilder.Entity<Ruangan>().HasData(
                new Ruangan
                {
                    Id = 1,
                    NamaRuangan = "C-303",
                    Kapasitas = 40,
                    Lokasi = "Gedung C Lantai 3",
                    Fasilitas = "Proyektor, AC, Whiteboard",
                    IsAktif = true
                },
                new Ruangan
                {
                    Id = 2,
                    NamaRuangan = "B-104",
                    Kapasitas = 35,
                    Lokasi = "Gedung B Lantai 1",
                    Fasilitas = "Proyektor, AC, Whiteboard, Sound System",
                    IsAktif = true
                },
                new Ruangan
                {
                    Id = 3,
                    NamaRuangan = "A-301",
                    Kapasitas = 50,
                    Lokasi = "Gedung A Lantai 3",
                    Fasilitas = "Proyektor, AC, Whiteboard, Komputer",
                    IsAktif = true
                }
            );
        }
    }
}