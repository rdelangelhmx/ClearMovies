using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    public class VwMovieConfiguration : IEntityTypeConfiguration<VwMovie>
    {
        public void Configure(EntityTypeBuilder<VwMovie> builder)
        {
            //builder.HasNoKey();
            builder.ToView("vwMovies");

            builder.Property(e => e.MovieId).ValueGeneratedNever().HasColumnName("movie_id");

            builder.Property(e => e.Budget).HasColumnName("budget");

            builder.Property(e => e.CharacterName)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("character_name");

            builder.Property(e => e.GenreName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("genre_name");

            builder.Property(e => e.Homepage)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("homepage");

            builder.Property(e => e.MovieStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("movie_status");

            builder.Property(e => e.Overview)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("overview");

            builder.Property(e => e.PersonName)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("person_name");

            builder.Property(e => e.Popularity)
                .HasColumnType("decimal(14, 8)")
                .HasColumnName("popularity");

            builder.Property(e => e.ReleaseDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("release_date");

            builder.Property(e => e.Revenue).HasColumnName("revenue");

            builder.Property(e => e.Runtime).HasColumnName("runtime");

            builder.Property(e => e.Tagline)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("tagline");

            builder.Property(e => e.Title)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("title");

            builder.Property(e => e.VoteAverage)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("vote_average");

            builder.Property(e => e.VoteCount).HasColumnName("vote_count");
        }
    }
}
