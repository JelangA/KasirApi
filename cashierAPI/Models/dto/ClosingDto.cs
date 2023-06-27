namespace cashierAPI.Models.dto
{
    public class ClosingDto
    {
        public int id_closing { get; set; }
        public string? AlamatPegiriman { get; set; }
        public int Status { get; set; }
        public int TotalHarga { get; set; }
        public int Quantity { get; set; }
        public int VariantId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
