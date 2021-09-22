using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Domain.Entities
{
    [Keyless]
    [Table("movie_languages")]
    public partial class MovieLanguage
    {
        [Column("movie_id")]
        public int? MovieId { get; set; }
        [Column("language_id")]
        public int? LanguageId { get; set; }
        [Column("language_role_id")]
        public int? LanguageRoleId { get; set; }

        [ForeignKey(nameof(LanguageId))]
        public virtual Language Language { get; set; }
        [ForeignKey(nameof(LanguageRoleId))]
        public virtual LanguageRole LanguageRole { get; set; }
        [ForeignKey(nameof(MovieId))]
        public virtual Movie Movie { get; set; }
    }
}
