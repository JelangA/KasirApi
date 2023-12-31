﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace cashierAPI.Models
{
    public class Product
    {

        [Key]
        public int id_product { get; set; }
        [Required]
        public string? jenis_product { get; set; }
        [Required]
        public string? nama_product { get; set; }
        [Required]
        public int harga_satuan { get; set; }
        [Required]
        public int total_stok { get; set; }
        [Required]
        public string? deskripsi { get; set; }
        [Required]
        public bool status { get; set; }

        [JsonIgnore]
        public ICollection<Variant> variants { get; } = new List<Variant>();
    }
}
