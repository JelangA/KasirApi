using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cashierAPI.Models
{
    public class DetailClosing
    {
        [Key]
        public int id_detail_closing { get; set; }

        [Required]
        public int closing_id { get; set; }

        [Required]
        public int variant_id { get; set; }

        [Required]
        public int konsumen_id { get; set; }

        [Required]
        public int quantity { get; set; }

        [Required]
        public int jumlah_harga { get; set; }
    }
}