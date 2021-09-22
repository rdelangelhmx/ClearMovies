using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class LanguageRoleConfiguration : IEntityTypeConfiguration<LanguageRole>
    {
        public void Configure(EntityTypeBuilder<LanguageRole> builder)
        {
            builder.HasKey(e => e.RoleId)
                .HasName("PK__language__760965CCE92B1C65");

            builder.Property(e => e.RoleId).ValueGeneratedNever();

            builder.Property(e => e.LanguageRole1).IsUnicode(false);
        }
    }
}
