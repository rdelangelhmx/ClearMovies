using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Domain.Entities
{
    [Table("language_role")]
    public partial class LanguageRole
    {
        [Key]
        [Column("role_id")]
        public int RoleId { get; set; }
        [Column("language_role")]
        [StringLength(20)]
        public string LanguageRole1 { get; set; }
    }
}
