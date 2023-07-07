using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace cashierAPI.Models
{
    public class User
    {
        [Key]
        public int id_user { get; set; }

        [Required]
        public required string nama_user { get; set; }

        [Required]
        public required string email { get; set; }

        [Required]
        public required string password { get; set; }

        [Required]
        public required string gender { get; set; }

        [Required]
        public required string no_telpon { get; set; }

        [Required]
        public required string alamat { get; set; }

        [JsonIgnore]
        public AkunCs? AkunCs { get; set; }
    }
}
