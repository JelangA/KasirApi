using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace cashierAPI.Models
{
    public class User
    {
        [Key]
        public int id_user { get; set; }
        [Required]
        public string? nama_user { get; set; }
        [Required]
        public string? email { get; set; }
        [Required]
        public string? password { get; set; }
        [Required]
        public string? gender { get; set; }
        [Required]
        public string? no_telpon { get; set; }
        [Required]
        public string? alamat { get; set; }

        [JsonIgnore]
        public AkunCs? AkunCs { get; set; }
    }
}
