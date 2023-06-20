using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cashierAPI.Models
{
    public class Closing
    {
        [Key]
        public int id_closing { get; set; }

        [Required]
        public int AkunCS_id { get; set; }

        public int? konsumen_id { get; set; }

        [Required]
        public string? alamat_pengiriman { get; set; }

        [Required]
        public int status { get; set; }

        [Required]
        public string? bukti_transfer { get; set; }

        [Required]
        public int total_harga { get; set; }

    }
}