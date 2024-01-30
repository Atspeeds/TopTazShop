using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TopTaz.Domain.CatalogAgg;

namespace TopTaz.Persistence.Mapping.CatalogMap
{
    public class CatalogBrandMapping : IEntityTypeConfiguration<CatalogBrand>
    {
        public void Configure(EntityTypeBuilder<CatalogBrand> builder)
        {
            builder.Property(x => x.Brand)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
