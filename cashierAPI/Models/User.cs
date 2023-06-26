using System.ComponentModel.DataAnnotations;

namespace cashierAPI.Models
{
    public class User
    {
        [Key]
        public int id_user { get; set; }
        public string? nama_user { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
        public string? gender { get; set; }
        public string? no_telp { get; set; }
        public string? alamat { get; set; }
        public string? role { get; set; }
        public AkunCS? akun { get; set; }
    }
}
