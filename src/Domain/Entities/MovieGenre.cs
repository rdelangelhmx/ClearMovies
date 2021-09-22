using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Domain.Entities
{
    [Keyless]
    [Table("movie_genres")]
    public partial class MovieGenre
    {
        [Column("movie_id")]
        public int? MovieId { get; set; }
        [Column("genre_id")]
        public int? GenreId { get; set; }

        [ForeignKey(nameof(GenreId))]
        public virtual Genre Genre { get; set; }
        [ForeignKey(nameof(MovieId))]
        public virtual Movie Movie { get; set; }
    }
}
