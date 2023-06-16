using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cashierAPI.Models{

    public class Closing{

        [Key]
        public int id_closing { get; set; }

        [Required]
        public string nama_barang { get; set; }

        [Required]
        public string nama_akun_cs { get; set; }

        [Required]
        public int jenis_barang { get; set; }

        [ForeignKey("Product")]
        public int id_barang { get; set; }

        [ForeignKey("AkunCS")]
        public int id_akun_cs { get; set; }

        [Required]
        public int quantity { get; set; }

        [Required]
        public string alamat_pengiriman { get; set; }

        [Required]
        public int status { get; set; }

        [Required]
        public string bukti_transfer { get; set; }

        [Required]
        public string nama_konsumen { get; set; }

        [Required]
        public int id_konsumen { get; set; }

        [Required]
        public string variant { get; set; }

        [Required]
        public int id_variant { get; set; }

        [Required]
        public string created_at { get; set; }

        [Required]
        public string updated_at { get; set; }

        [Required]
        public int total_harga { get; set; }

        public AkunCS? AkunCS { get; internal set; }
        public Product? product { get; internal set; }
        public Konsumen? Konsumen { get; internal set; }
        public Variant? Variant { get; internal set; }

    }
}