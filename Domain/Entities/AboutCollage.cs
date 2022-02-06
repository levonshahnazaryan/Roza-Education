using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("AboutCollage")]
    public class AboutCollage
    {
        [Key]
        [Column("AboutCollageId")]
        [JsonProperty("AboutCollageId")]
        public int AboutCollageId { get; set; }

        [Column("UContent")]
        [JsonProperty("UContent")]
        public string UContent { get; set; }
    }
}