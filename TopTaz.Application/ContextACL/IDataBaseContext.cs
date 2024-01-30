using System.Threading.Tasks;
using System.Threading;
using TopTaz.Domain.UserAgg;
using Microsoft.EntityFrameworkCore;
using TopTaz.Domain.CatalogAgg;

namespace TopTaz.Application.ContextACL
{
    public interface IDataBaseContext
    {
        public DbSet<CatalogBrand> CatalogBrands { get; set; }
        public DbSet<CatalogType> CatalogTypes { get; set; }
        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
