using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Domain.Entities
{
    [Table("genre")]
    public partial class Genre
    {
        [Key]
        [Column("genre_id")]
        public int GenreId { get; set; }
        [Column("genre_name")]
        [StringLength(100)]
        public string GenreName { get; set; }
    }
}
