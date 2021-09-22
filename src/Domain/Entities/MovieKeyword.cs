using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Domain.Entities
{
    [Keyless]
    [Table("movie_keywords")]
    public partial class MovieKeyword
    {
        [Column("movie_id")]
        public int? MovieId { get; set; }
        [Column("keyword_id")]
        public int? KeywordId { get; set; }

        [ForeignKey(nameof(KeywordId))]
        public virtual Keyword Keyword { get; set; }
        [ForeignKey(nameof(MovieId))]
        public virtual Movie Movie { get; set; }
    }
}
