using System.ComponentModel.DataAnnotations;

namespace cashierAPI.Models.dto;

public class AkunCSDto
{
    [Required]
    public int? user_id { get; set; }
    [Required]
    public bool status { get; set; }
}
