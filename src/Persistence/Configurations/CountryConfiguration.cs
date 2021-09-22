using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.Property(e => e.CountryId).ValueGeneratedNever();

            builder.Property(e => e.CountryIsoCode).IsUnicode(false);

            builder.Property(e => e.CountryName).IsUnicode(false);
        }
    }
}
