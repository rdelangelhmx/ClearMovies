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
            builder.ToView("vwMovies");

            builder.Property(e => e.Homepage).IsUnicode(false);

            builder.Property(e => e.MovieStatus).IsUnicode(false);

            builder.Property(e => e.Overview).IsUnicode(false);

            builder.Property(e => e.Tagline).IsUnicode(false);

            builder.Property(e => e.Title).IsUnicode(false);
        }
    }
}
