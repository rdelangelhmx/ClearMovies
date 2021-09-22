using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class MovieCastConfiguration : IEntityTypeConfiguration<MovieCast>
    {
        public void Configure(EntityTypeBuilder<MovieCast> builder)
        {
            builder.Property(e => e.CharacterName).IsUnicode(false);

            builder.HasOne(d => d.Gender)
                .WithMany()
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("fk_mca_gender");

            builder.HasOne(d => d.Movie)
                .WithMany()
                .HasForeignKey(d => d.MovieId)
                .HasConstraintName("fk_mca_movie");

            builder.HasOne(d => d.Person)
                .WithMany()
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("fk_mca_per");
        }
    }
}
