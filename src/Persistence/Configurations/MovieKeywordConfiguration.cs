using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class MovieKeywordConfiguration : IEntityTypeConfiguration<MovieKeyword>
    {
        public void Configure(EntityTypeBuilder<MovieKeyword> builder)
        {
            builder.HasOne(d => d.Keyword)
                .WithMany()
                .HasForeignKey(d => d.KeywordId)
                .HasConstraintName("fk_mk_keyword");

            builder.HasOne(d => d.Movie)
                .WithMany()
                .HasForeignKey(d => d.MovieId)
                .HasConstraintName("fk_mk_movie");
        }
    }
}
