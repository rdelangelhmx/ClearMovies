using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Domain.Entities
{
    [Keyless]
    [Table("production_country")]
    public partial class ProductionCountry
    {
        [Column("movie_id")]
        public int? MovieId { get; set; }
        [Column("country_id")]
        public int? CountryId { get; set; }

        [ForeignKey(nameof(CountryId))]
        public virtual Country Country { get; set; }
        [ForeignKey(nameof(MovieId))]
        public virtual Movie Movie { get; set; }
    }
}
