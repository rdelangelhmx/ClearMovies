using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class ProductionCountryConfiguration : IEntityTypeConfiguration<ProductionCountry>
    {
        public void Configure(EntityTypeBuilder<ProductionCountry> builder)
        {
            builder.HasOne(d => d.Country)
                .WithMany()
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("fk_pc_country");

            builder.HasOne(d => d.Movie)
                .WithMany()
                .HasForeignKey(d => d.MovieId)
                .HasConstraintName("fk_pc_movie");
        }
    }
}
