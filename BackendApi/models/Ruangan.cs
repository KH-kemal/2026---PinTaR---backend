namespace BackendApi.Models
{
    public class Ruangan
    {
        public int Id { get; set; }
        public required string NamaRuangan { get; set; }
        public int Kapasitas { get; set; }
        public required string Lokasi { get; set; }
        public string? Fasilitas { get; set; }
        public bool IsAktif { get; set; } = true;
    }
}
