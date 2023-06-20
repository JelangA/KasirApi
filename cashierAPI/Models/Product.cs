using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cashierAPI.Models
{
    public class Product
    {
        [Key]
        public int id_product { get; set; }

        [Required]
        public int jenis_barang_id { get; set; }

        [Required]
        public string? nama_product { get; set; }

        [Required]
        public int harga { get; set; }

        [Required]
        public int total_stock { get; set; }

        public string? deskripsi { get; set; }

        [Required]
        public bool status { get; set; }

    }

}