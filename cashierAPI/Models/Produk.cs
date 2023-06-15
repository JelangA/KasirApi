using System.ComponentModel.DataAnnotations;

namespace cashierAPI.Models{
    
    public class Product{

        [Key]
        public int id_product { get; set; }

        [Required]
        public string? nama_product { get; set; }

        [Required]
        public int jenis_barang { get; set; }

        [Required]
        public int harga { get; set; }

        [Required]
        public int total_stock { get; set; }

        [Required]
        public string? deskripsi { get; set; }

        [Required]
        public List<Variant>? list_variant { get; set; }

        [Required]
        public bool status { get; set; }

    }
}