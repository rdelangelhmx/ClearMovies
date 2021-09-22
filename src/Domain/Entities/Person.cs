using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Domain.Entities
{
    [Table("person")]
    public partial class Person
    {
        [Key]
        [Column("person_id")]
        public int PersonId { get; set; }
        [Column("person_name")]
        [StringLength(500)]
        public string PersonName { get; set; }
    }
}
