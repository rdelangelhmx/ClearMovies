using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class MovieCompanyConfiguration : IEntityTypeConfiguration<MovieCompany>
    {
        public void Configure(EntityTypeBuilder<MovieCompany> builder)
        {
            builder.HasOne(d => d.Company)
                .WithMany()
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("fk_mc_comp");

            builder.HasOne(d => d.Movie)
                .WithMany()
                .HasForeignKey(d => d.MovieId)
                .HasConstraintName("fk_mc_movie");
        }
    }
}
