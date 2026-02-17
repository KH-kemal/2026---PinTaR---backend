using Microsoft.AspNetCore.Mvc;
using BackendApi.Data;
using BackendApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RuanganController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RuanganController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ruangan
        [HttpGet]
        public IActionResult GetAll()
        {
            var ruangan = _context.Ruangan.Where(r => r.IsAktif).ToList();
            return Ok(ruangan);
        }

        // GET: api/ruangan/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var ruangan = _context.Ruangan.Find(id);
            if (ruangan == null)
                return NotFound();

            return Ok(ruangan);
        }

        // GET: api/ruangan/tersedia?tanggalPinjam=2026-02-20&tanggalSelesai=2026-02-22
        [HttpGet("tersedia")]
        public IActionResult GetRuanganTersedia(DateTime tanggalPinjam, DateTime tanggalSelesai)
        {
            // Validasi input
            if (tanggalPinjam >= tanggalSelesai)
            {
                return BadRequest("Tanggal pinjam harus lebih awal dari tanggal selesai");
            }

            // Cari ruangan yang tidak sedang dipinjam pada range tanggal tersebut
            var ruanganDipinjam = _context.Peminjaman
                .Where(p => p.Status == "Disetujui" || p.Status == "Menunggu")
                .Where(p => 
                    // Cek apakah ada overlap tanggal
                    (p.TanggalPinjam <= tanggalSelesai && p.TanggalSelesai >= tanggalPinjam))
                .Select(p => p.NamaRuangan)
                .Distinct()
                .ToList();

            // Ambil ruangan yang tidak ada dalam list ruangan yang dipinjam
            var ruanganTersedia = _context.Ruangan
                .Where(r => r.IsAktif && !ruanganDipinjam.Contains(r.NamaRuangan))
                .ToList();

            return Ok(new
            {
                tanggalPinjam = tanggalPinjam.ToString("yyyy-MM-dd"),
                tanggalSelesai = tanggalSelesai.ToString("yyyy-MM-dd"),
                jumlahRuanganTersedia = ruanganTersedia.Count,
                ruanganTersedia = ruanganTersedia
            });
        }

        // POST: api/ruangan
        [HttpPost]
        public IActionResult Create(Ruangan ruangan)
        {
            _context.Ruangan.Add(ruangan);
            _context.SaveChanges();
            return Ok(ruangan);
        }

        // PUT: api/ruangan/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, Ruangan updated)
        {
            var ruangan = _context.Ruangan.Find(id);
            if (ruangan == null)
                return NotFound();

            ruangan.NamaRuangan = updated.NamaRuangan;
            ruangan.Kapasitas = updated.Kapasitas;
            ruangan.Lokasi = updated.Lokasi;
            ruangan.Fasilitas = updated.Fasilitas;
            ruangan.IsAktif = updated.IsAktif;

            _context.SaveChanges();
            return Ok(ruangan);
        }

        // DELETE: api/ruangan/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var ruangan = _context.Ruangan.Find(id);
            if (ruangan == null)
                return NotFound();

            // Soft delete - set IsAktif ke false
            ruangan.IsAktif = false;
            _context.SaveChanges();
            return Ok();
        }
    }
}
