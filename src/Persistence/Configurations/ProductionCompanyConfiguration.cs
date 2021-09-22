using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class ProductionCompanyConfiguration : IEntityTypeConfiguration<ProductionCompany>
    {
        public void Configure(EntityTypeBuilder<ProductionCompany> builder)
        {
            builder.HasKey(e => e.CompanyId)
                .HasName("PK__producti__3E267235949FCD78");

            builder.Property(e => e.CompanyId).ValueGeneratedNever();

            builder.Property(e => e.CompanyName).IsUnicode(false);
        }
    }
}
