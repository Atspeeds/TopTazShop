using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TopTaz.Domain.CatalogAgg;

namespace TopTaz.Persistence.Mapping.CatalogMap
{
    public class CatalogTypeMapping : IEntityTypeConfiguration<CatalogType>
    {
        public void Configure(EntityTypeBuilder<CatalogType> builder)
        {

            builder.Property(x => x.Type)
                .HasMaxLength(100).IsRequired();


        }
    }
}
