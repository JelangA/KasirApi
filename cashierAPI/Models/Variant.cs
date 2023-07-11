using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace cashierAPI.Models
{
    public class Variant
    {
        [Key]
        public int id_variant { get; set; }
        [Required]
        public string? nama_variant { get; set; }
        [Required]
        public int harga_tambahan { get; set; }
        [Required]
        public int stok { get; set; }
        [Required]
        public string? keterangan { get; set; }
        [Required]
        public DateTime expired_date { get; set; }
        [ForeignKey("Product")]
        public int product_id { get; set; }

        [JsonIgnore]
        public Product? product { get; set; }
        [JsonIgnore]
        public ICollection<Closing> closings { get; } = new List<Closing>();
    }
}
