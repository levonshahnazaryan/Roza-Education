using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Educations")]
    public class Educations
    {
        [Key]
        [Column("EducationsId")]
        [JsonProperty("EducationsId")]
        public int EducationsId { get; set; }

        [Column("ParentId")]
        [JsonProperty("ParentId")]
        public int ParentId { get; set; }

        [Column("State")]
        [JsonProperty("State")]
        public bool State { get; set; }

        [Column("IsBest")]
        [JsonProperty("IsBest")]
        public bool IsBest { get; set; }

        [Column("UName")]
        [JsonProperty("UName")]
        public string UName { get; set; }

        [Column("UContent")]
        [JsonProperty("UContent")]
        public string UContent { get; set; }
    }
}
