using Microsoft.AspNetCore.Mvc;
using BackendApi.Data;
using BackendApi.Models;

namespace BackendApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeminjamanController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PeminjamanController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/peminjaman
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Peminjaman.ToList());
        }

        // GET: api/peminjaman/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var data = _context.Peminjaman.Find(id);
            if (data == null)
                return NotFound();

            return Ok(data);
        }
        // GET: api/peminjaman/search?keyword=Lab
        [HttpGet("search")]
        public IActionResult Search(string keyword)
        {
            var result = _context.Peminjaman
                .Where(p => p.NamaPeminjam.Contains(keyword)
                        || p.NamaRuangan.Contains(keyword))
                .ToList();

            return Ok(result);
        }

        // POST
        [HttpPost]
        public IActionResult Create(Peminjaman peminjaman)
        {
            _context.Peminjaman.Add(peminjaman);
            _context.SaveChanges();
            return Ok(peminjaman);
        }

        // PUT
        [HttpPut("{id}")]
        public IActionResult Update(int id, Peminjaman updated)
        {
            var data = _context.Peminjaman.Find(id);
            if (data == null)
                return NotFound();

            data.NamaPeminjam = updated.NamaPeminjam;
            data.NamaRuangan = updated.NamaRuangan;
            data.TanggalPinjam = updated.TanggalPinjam;
            data.TanggalSelesai = updated.TanggalSelesai;
            data.Keperluan = updated.Keperluan;
            data.Status = updated.Status;

            _context.SaveChanges();
            return Ok(data);
        }

        // DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = _context.Peminjaman.Find(id);
            if (data == null)
                return NotFound();

            _context.Peminjaman.Remove(data);
            _context.SaveChanges();
            return Ok();
        }
    }
}