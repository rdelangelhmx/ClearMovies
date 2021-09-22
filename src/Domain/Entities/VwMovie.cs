using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    //[Keyless]
    public partial class VwMovie
    {
        //[Key]
        public int MovieId { get; set; }
        public string Title { get; set; }
        public long? Budget { get; set; }
        public string Homepage { get; set; }
        public string Overview { get; set; }
        public decimal? Popularity { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public long? Revenue { get; set; }
        public int? Runtime { get; set; }
        public string MovieStatus { get; set; }
        public string Tagline { get; set; }
        public decimal? VoteAverage { get; set; }
        public int? VoteCount { get; set; }
        public string GenreName { get; set; }
        public string PersonName { get; set; }
        public string CharacterName { get; set; }
    }
}
