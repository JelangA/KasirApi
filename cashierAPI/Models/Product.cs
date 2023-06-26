using System.ComponentModel.DataAnnotations;

namespace cashierAPI.Models
{
    public class Product
    {
        [Key]
        public int id_product { get; set; }
        public int jenis_product { get; set; }
        public string nama_product { get; set; }
        public ICollection<Variant> variants { get; } = new List<Variant>();
    }
}
