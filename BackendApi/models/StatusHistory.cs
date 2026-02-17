namespace BackendApi.Models
{
    public class StatusHistory
    {
        public int Id { get; set; }
        public int PeminjamanId { get; set; }
        public required string StatusLama { get; set; }
        public required string StatusBaru { get; set; }
        public DateTime TanggalPerubahan { get; set; }
    }
}