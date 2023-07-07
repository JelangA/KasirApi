using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace cashierAPI.Models.dto
{
    public class ProductDto
    {
        public int id_product { get; set; }
        public required string jenis_product { get; set; }
        public required string nama_product { get; set; }
        public int harga_satuan { get; set; }
        public int total_stok { get; set; }
        public string? deskripsi { get; set; }
        public bool status { get; set; }


    }
}