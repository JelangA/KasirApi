using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using cashierAPI.Models;

namespace cashierAPI.dto;

public class ClosingResponseDto
{
    [Key]
    public int id_closing { get; set; }
    [Required]
    public string? alamat_pegiriman { get; set; }
    [Required]
    public int status { get; set; }
    [Required]
    public int total_harga { get; set; }
    [Required]
    public int quantity { get; set; }
    [ForeignKey("Variant")]
    public int variant_id { get; set; }
    [ForeignKey("Konsumen")]
    public int? konsumen_id { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }

    public Variant? variant { get; set; }
    public Konsumen? konsumen { get; set; }
}
