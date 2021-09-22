using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Domain.Entities
{
    [Table("language")]
    public partial class Language
    {
        [Key]
        [Column("language_id")]
        public int LanguageId { get; set; }
        [Column("language_code")]
        [StringLength(10)]
        public string LanguageCode { get; set; }
        [Column("language_name")]
        [StringLength(500)]
        public string LanguageName { get; set; }
    }
}
