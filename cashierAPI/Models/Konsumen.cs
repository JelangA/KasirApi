using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace cashierAPI.Models
{
    public class Konsumen
    {
        [Key]
        public int id_Konsumen { get; set; }
        [ForeignKey("AkunCs")]
        public int? AkunCs_id { get; set; }
        [Required]
        public string? nama_konsumen { get; set; }
        [Required]
        public string? kontak { get; set; }

        [JsonIgnore]
        public AkunCs? AkunCs { get; set; }
        [JsonIgnore]
        public ICollection<Closing>? Closings { get; set; }
    }
}

