using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cashierAPI.Models
{
    public class AkunCS
    {
        [Key]
        public int id_akun { get; set; }

        [Required]
        public string? nama { get; set; }

        [Required]
        public string? no_tlp { get; set; }

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
