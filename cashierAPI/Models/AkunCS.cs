using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace cashierAPI.Models
{
    public class AkunCs
    {
        [Key]
        public int id_akunCs { get; set; }

        [ForeignKey("User")]
        public int id_user { get; set; }

        [Required]
        public bool status { get; set; }

        [JsonIgnore]
        public User? User { get; set; }

    }
}
