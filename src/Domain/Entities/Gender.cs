using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Domain.Entities
{
    [Table("gender")]
    public partial class Gender
    {
        [Key]
        [Column("gender_id")]
        public int GenderId { get; set; }
        [Column("gender")]
        [StringLength(20)]
        public string Gender1 { get; set; }
    }
}
