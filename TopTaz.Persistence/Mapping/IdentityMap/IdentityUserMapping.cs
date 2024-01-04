using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TopTaz.Persistence.Mapping.IdentityMap
{
    internal class IdentityUserMapping : IEntityTypeConfiguration<IdentityUser<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUser<string>> builder)
        {
            builder.ToTable("Users");
        }
    }
}
