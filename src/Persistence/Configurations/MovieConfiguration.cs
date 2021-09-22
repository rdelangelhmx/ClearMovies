using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Persistence.Configurations
{
    class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.Property(e => e.MovieId).ValueGeneratedNever();

            builder.Property(e => e.Homepage).IsUnicode(false);

            builder.Property(e => e.MovieStatus).IsUnicode(false);

            builder.Property(e => e.Overview).IsUnicode(false);

            builder.Property(e => e.Tagline).IsUnicode(false);

            builder.Property(e => e.Title).IsUnicode(false);
        }
    }
}
