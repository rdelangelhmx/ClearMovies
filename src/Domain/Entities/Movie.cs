using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Domain.Entities
{
    [Table("movie")]
    public partial class Movie
    {
        [Key]
        [Column("movie_id")]
        public int MovieId { get; set; }
        [Column("title")]
        [StringLength(1000)]
        public string Title { get; set; }
        [Column("budget")]
        public long? Budget { get; set; }
        [Column("homepage")]
        [StringLength(1000)]
        public string Homepage { get; set; }
        [Column("overview")]
        [StringLength(1000)]
        public string Overview { get; set; }
        [Column("popularity", TypeName = "decimal(14, 8)")]
        public decimal? Popularity { get; set; }
        [Column("release_date", TypeName = "smalldatetime")]
        public DateTime? ReleaseDate { get; set; }
        [Column("revenue")]
        public long? Revenue { get; set; }
        [Column("runtime")]
        public int? Runtime { get; set; }
        [Column("movie_status")]
        [StringLength(50)]
        public string MovieStatus { get; set; }
        [Column("tagline")]
        [StringLength(1000)]
        public string Tagline { get; set; }
        [Column("vote_average", TypeName = "decimal(4, 2)")]
        public decimal? VoteAverage { get; set; }
        [Column("vote_count")]
        public int? VoteCount { get; set; }
    }
}
