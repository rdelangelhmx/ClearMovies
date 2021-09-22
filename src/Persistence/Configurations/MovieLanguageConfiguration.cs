using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class MovieLanguageConfiguration : IEntityTypeConfiguration<MovieLanguage>
    {
        public void Configure(EntityTypeBuilder<MovieLanguage> builder)
        {
            builder.HasOne(d => d.Language)
                .WithMany()
                .HasForeignKey(d => d.LanguageId)
                .HasConstraintName("fk_ml_lang");

            builder.HasOne(d => d.LanguageRole)
                .WithMany()
                .HasForeignKey(d => d.LanguageRoleId)
                .HasConstraintName("fk_ml_role");

            builder.HasOne(d => d.Movie)
                .WithMany()
                .HasForeignKey(d => d.MovieId)
                .HasConstraintName("fk_ml_movie");
        }
    }
}
