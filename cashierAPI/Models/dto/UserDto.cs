using System.ComponentModel.DataAnnotations;

namespace cashierAPI.Models.dto;

public class UserDto
{
    [Required]
    public string? nama_user { get; set; }
    [Required]
    public string? email { get; set; }
    [Required]
    public string? password { get; set; }
    [Required]
    public string? gender { get; set; }
    [Required]
    public string? no_telpon { get; set; }
    [Required]
    public string? alamat { get; set; }
}
