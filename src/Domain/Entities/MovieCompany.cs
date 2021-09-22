using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Domain.Entities
{
    [Keyless]
    [Table("movie_company")]
    public partial class MovieCompany
    {
        [Column("movie_id")]
        public int? MovieId { get; set; }
        [Column("company_id")]
        public int? CompanyId { get; set; }

        [ForeignKey(nameof(CompanyId))]
        public virtual ProductionCompany Company { get; set; }
        [ForeignKey(nameof(MovieId))]
        public virtual Movie Movie { get; set; }
    }
}
