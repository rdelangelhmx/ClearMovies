using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Domain.Entities
{
    [Keyless]
    [Table("movie_cast")]
    public partial class MovieCast
    {
        [Column("movie_id")]
        public int? MovieId { get; set; }
        [Column("person_id")]
        public int? PersonId { get; set; }
        [Column("character_name")]
        [StringLength(400)]
        public string CharacterName { get; set; }
        [Column("gender_id")]
        public int? GenderId { get; set; }
        [Column("cast_order")]
        public int? CastOrder { get; set; }

        [ForeignKey(nameof(GenderId))]
        public virtual Gender Gender { get; set; }
        [ForeignKey(nameof(MovieId))]
        public virtual Movie Movie { get; set; }
        [ForeignKey(nameof(PersonId))]
        public virtual Person Person { get; set; }
    }
}
