using System.ComponentModel.DataAnnotations;

namespace cashierAPI.Models
{
    public class User
    {
        [Key]
        public int id_user { get; set; }
        [Required]
        public string nama_user { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public string no_telp { get; set; }
        [Required]
        public string alamat { get; set; }
        [Required]
        public string role { get; set; }

        public AkunCS? akun { get; set; }
    }
}
