using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("UsefulLinks")]
    public class UsefulLinks
    {
        [Key]
        [Column("UsefulLinksId")]
        [JsonProperty("UsefulLinksId")]
        public int UsefulLinksId { get; set; }

        [Column("Img")]
        [JsonProperty("Img")]
        public string Img { get; set; }

        [Column("Url")]
        [JsonProperty("Url")]
        public string Url { get; set; }

        [Column("UName")]
        [JsonProperty("UName")]
        public string UName { get; set; }

        [Column("State")]
        [JsonProperty("State")]
        public bool State { get; set; }

        [Column("Sorting")]
        [JsonProperty("Sorting")]
        public int Sorting { get; set; }
    }
}