using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace cashierAPI.Models
{
    public class Variant
    {
        [Key]
        public int id_variant { get; set; }
        public string? nama_variant { get; set; }
        public int harga_tambahan { get; set; }
        public int stok { get; set; }
        public string? keterangan { get; set; }
        public DateTime expired_date { get; set; }
        public int product_id { get; set; }

        [JsonIgnore]
        public Product? product { get; set; }

        [JsonIgnore]
        public Closing? closing { get; set; }
    }
}
