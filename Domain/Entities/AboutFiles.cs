using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("AboutFiles")]
    public class AboutFiles
    {
        [Key]
        [Column("AboutFilesId")]
        [JsonProperty("AboutFilesId")]
        public int AboutFilesId { get; set; }

        [Column("FileName")]
        [JsonProperty("FileName")]
        public string FileName { get; set; }
    }
}