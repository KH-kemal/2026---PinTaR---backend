namespace BackendApi.Models
{
    public class Peminjaman
    {
        public int Id { get; set; }
        public required string NamaPeminjam { get; set; }
        public required string NRP { get; set; }
        public required string NamaRuangan { get; set; }
        public DateTime TanggalPinjam { get; set; }
        public DateTime TanggalSelesai { get; set; }
        public required string Keperluan { get; set; }
        public string Status { get; set; } = "Menunggu";
    }
}
