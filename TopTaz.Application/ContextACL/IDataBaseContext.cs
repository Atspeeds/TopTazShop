using System.Threading.Tasks;
using System.Threading;
using TopTaz.Domain.UserAgg;
using Microsoft.EntityFrameworkCore;
using TopTaz.Domain.CatalogAgg;
using TopTaz.Domain.BasketAgg;

namespace TopTaz.Application.ContextACL
{
    public interface IDataBaseContext
    {
        public DbSet<CatalogItem> CatalogItems { get; set; }
        public DbSet<CatalogBrand> CatalogBrands { get; set; }
        public DbSet<CatalogType> CatalogTypes { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
