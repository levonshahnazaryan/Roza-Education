using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("VideoEducation")]
    public class VideoEducation
    {
        [Key]
        [Column("VideoEducationId")]
        [JsonProperty("VideoEducationId")]
        public int VideoEducationId { get; set; }

        [Column("FileName")]
        [JsonProperty("FileName")]
        public string FileName { get; set; }
    }
}