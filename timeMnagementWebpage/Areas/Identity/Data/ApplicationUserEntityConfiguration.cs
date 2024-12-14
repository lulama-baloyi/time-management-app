using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace timeMnagementWebpage.Areas.Identity.Data
{
    internal class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<sampleUser>
    {
        public void Configure(EntityTypeBuilder<sampleUser> builder)
        {
           builder.Property(x => x.Name).HasMaxLength(128);
            builder.Property(x => x.Surname).HasMaxLength(128);
        }
    }
}