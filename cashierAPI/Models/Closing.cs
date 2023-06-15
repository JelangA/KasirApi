using System.ComponentModel.DataAnnotations;

namespace cashierAPI.Models{

    public class Closing{

        [Key]
        public int id_closing { get; set; }

        [Required]
        public string? nama_barang { get; set; }

        [Required]
        public string? nama_akun_cs { get; set; }

        [Required]
        public int jenis_barang { get; set; }

        [Required]
        public int id_barang { get; set; }

        [Required]
        public int id_akun_cs { get; set; }

        [Required]
        public int quantity { get; set; }

        [Required]
        public string? alamat_pengiriman { get; set; }

        [Required]
        public int status { get; set; }

        [Required]
        public string? bukti_transfer { get; set; }

        [Required]
        public string? nama_konsumen { get; set; }

        [Required]
        public int id_konsumen { get; set; }

        [Required]
        public string? variant { get; set; }

        [Required]
        public int id_variant { get; set; }

        [Required]
        public string? created_at { get; set; }

        [Required]
        public string? updated_at { get; set; }

        [Required]
        public int total_harga { get; set; }


    }
}