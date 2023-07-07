using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace cashierAPI.Models
{
    public class Konsumen {
        [Key]
        public int id_Konsumen { get; set; }
        public int AkunCs_id { get; set; }
        public required string nama_konsumen { get; set; }
        public required string kontak { get; set; }
    }
}

