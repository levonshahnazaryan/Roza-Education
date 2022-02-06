using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("AboutUs")]
    public class AboutUs
    {
        [Key]
        [Column("AboutUsId")]
        [JsonProperty("AboutUsId")]
        public int AboutUsId { get; set; }

        [Column("UContent")]
        [JsonProperty("UContent")]
        public string UContent { get; set; }
    }
}