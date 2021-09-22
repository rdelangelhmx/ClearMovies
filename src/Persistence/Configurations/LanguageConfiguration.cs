using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.Property(e => e.LanguageId).ValueGeneratedNever();

            builder.Property(e => e.LanguageCode).IsUnicode(false);

            builder.Property(e => e.LanguageName).IsUnicode(false);
        }
    }
}
