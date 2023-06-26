using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cashierAPI.Models
{
    public class AkunCS
    {
        [Key]
        public int id_akunCS { get; set; }
        public int id_user { get; set; }
        public bool status { get; set; }
        public User User { get; set; } = null!;
    }

}