using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("EducationsFile")]
    public class EducationsFile
    {
        [Key]
        [Column("EducationsFileId")]
        [JsonProperty("EducationsFileId")]
        public int EducationsFileId { get; set; }

        [Column("EducationsId")]
        [JsonProperty("EducationsId")]
        public int EducationsId { get; set; }

        [Column("FileName")]
        [JsonProperty("FileName")]
        public string FileName { get; set; }

        [ForeignKey("EducationsId")]
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual Educations Educations { get; set; }
    }
}
