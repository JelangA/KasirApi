using System.ComponentModel.DataAnnotations;

namespace cashierAPI.Models{
    public class Konsumen{
        
        [Key]
        public int id_konsumen { get; set; }

        [Required]
        public int id_akun { get; set; }

        [Required]
        public string? nama_akun_cs { get; set; }

        [Required]
        public string? nama_konsumen { get; set; }

        [Required]
        public int kontak { get; set; }
    }
}