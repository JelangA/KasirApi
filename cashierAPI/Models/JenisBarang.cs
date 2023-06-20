
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cashierAPI.Models
{
    public class JenisBarang
    {
        [Key]
        public int id_jenis_barang { get; set; }

        [Required]
        public string? nama_jenis_barang { get; set; }
    }
}