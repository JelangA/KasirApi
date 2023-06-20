using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cashierAPI.Models
{
    public class Konsumen
    {
        [Key]
        public int id_konsumen { get; set; }

        [Required]
        public string? nama_akun { get; set; }

        [Required]
        public string? kontak { get; set; }
    }
}