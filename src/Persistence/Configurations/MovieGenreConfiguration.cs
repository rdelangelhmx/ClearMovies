using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class MovieGenreConfiguration : IEntityTypeConfiguration<MovieGenre>
    {
        public void Configure(EntityTypeBuilder<MovieGenre> builder)
        {
            builder.HasOne(d => d.Genre)
                .WithMany()
                .HasForeignKey(d => d.GenreId)
                .HasConstraintName("fk_mg_genre");

            builder.HasOne(d => d.Movie)
                .WithMany()
                .HasForeignKey(d => d.MovieId)
                .HasConstraintName("fk_mg_movie");
        }
    }
}
