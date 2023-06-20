using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cashierAPI.Models
{
    public class AkunCS
    {
        [Key]
        public int id_akunCS { get; set; }

        [Required]
        public string? nama { get; set; }

        [Required]
        public string? no_telp { get; set; }

        [Required]
        public string? password { get; set; }

        [Required]
        public string? alamat { get; set; }

        [Required]
        public string? gender { get; set; }

        [Required]
        public bool status { get; set; }
    }

}