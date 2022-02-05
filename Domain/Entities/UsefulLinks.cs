using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("UsefulLinks")]
    public class UsefulLinks
    {
        [Key]
        [Column("UsefulLinksId")]
        public int UsefulLinksId { get; set; }

        [Column("Img")]
        public string Img { get; set; }

        [Column("Url")]
        public string Url { get; set; }

        [Column("UName")]
        public string UName { get; set; }

        [Column("State")]
        public bool State { get; set; }

        [Column("Sort")]
        public int Sort { get; set; }
    }
}