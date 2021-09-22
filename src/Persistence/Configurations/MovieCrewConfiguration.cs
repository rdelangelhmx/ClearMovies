using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class MovieCrewConfiguration : IEntityTypeConfiguration<MovieCrew>
    {
        public void Configure(EntityTypeBuilder<MovieCrew> builder)
        {
            builder.Property(e => e.Job).IsUnicode(false);

            builder.HasOne(d => d.Department)
                .WithMany()
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("fk_mcr_dept");

            builder.HasOne(d => d.Movie)
                .WithMany()
                .HasForeignKey(d => d.MovieId)
                .HasConstraintName("fk_mcr_movie");

            builder.HasOne(d => d.Person)
                .WithMany()
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("fk_mcr_per");
        }
    }
}
