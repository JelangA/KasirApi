using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cashierAPI.Models{
    public class Konsumen{
        
        [Key]
        public int id_konsumen { get; set; }

        [ForeignKey("AkunCS")]
        public int id_akun_cs { get; set; }

        [Required]
        public string nama_akun_cs { get; set; }

        [Required]
        public string nama_konsumen { get; set; }

        [Required]
        public int kontak { get; set; }
        
        public AkunCS AkunCS { get; internal set; }
    }
}