using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace cashierAPI.Models
{
    public class Product
    {
        private int id_product1;

        [Key]
        public int id_product { get; set; }
        public string jenis_product { get; set; }
        public string nama_product { get; set; }
        public int harga_satuan { get; set; } 
        public int total_stok { get; set; } 
        public string? deskripsi { get; set; }
        public bool status { get; set; }

        public ICollection<Variant> variants { get; } = new List<Variant>();
    }
}
