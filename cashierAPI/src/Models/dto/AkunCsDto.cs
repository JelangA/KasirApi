using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace cashierAPI.Models.dto
{
    public class AkunCsDto
    {
        public int id_akunCs { get; set; }
        public int id_user { get; set; }
        public bool status { get; set; }
    }
}