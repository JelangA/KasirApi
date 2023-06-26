using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace cashierAPI.Models
{
    public class Variant
    {
        [Key]
        public int id_variant { get; set; }
        public string nama_variant { get; set; }
        public int product_id { get; set; }

        [JsonIgnore]
        public Product? product { get; set; }
    }
}
