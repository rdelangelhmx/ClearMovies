using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Domain.Entities
{
    [Table("keyword")]
    public partial class Keyword
    {
        [Key]
        [Column("keyword_id")]
        public int KeywordId { get; set; }
        [Column("keyword_name")]
        [StringLength(50)]
        public string KeywordName { get; set; }
    }
}
