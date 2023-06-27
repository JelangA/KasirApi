using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace cashierAPI.Models
{
    public class Closing
    {
        [Key]
        public int id_closing { get; set; }
        public string alamat_pegiriman { get; set; }
        public int status { get; set; }
        public int total_harga { get; set; }
        public int quantity { get; set; }
        public int variant_id { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }

        public Variant? variant { get; set; }
    }
}
