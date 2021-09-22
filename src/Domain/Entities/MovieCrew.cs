using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Domain.Entities
{
    [Keyless]
    [Table("movie_crew")]
    public partial class MovieCrew
    {
        [Column("movie_id")]
        public int? MovieId { get; set; }
        [Column("person_id")]
        public int? PersonId { get; set; }
        [Column("department_id")]
        public int? DepartmentId { get; set; }
        [Column("job")]
        [StringLength(200)]
        public string Job { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        public virtual Department Department { get; set; }
        [ForeignKey(nameof(MovieId))]
        public virtual Movie Movie { get; set; }
        [ForeignKey(nameof(PersonId))]
        public virtual Person Person { get; set; }
    }
}
