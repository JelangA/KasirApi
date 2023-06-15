using System.ComponentModel.DataAnnotations;

namespace cashierAPI.Models{

    public class Variant{

        [Key]
        public int id_variant { get; set; }

        [Required]
        public string? nama_variant { get; set; }

        [Required]
        public int harga_tambahan { get; set; }

        [Required]
        public int stok { get; set; }

        [Required]
        public string? keterangan { get; set; }
    }
}