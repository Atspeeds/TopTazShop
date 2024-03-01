using System.Threading.Tasks;
using System.Threading;
using TopTaz.Domain.UserAgg;
using Microsoft.EntityFrameworkCore;
using TopTaz.Domain.CatalogAgg;
using TopTaz.Domain.BasketAgg;
using TopTaz.Domain.OrderAgg;
using TopTaz.Domain.PaymentAgg;
using TopTaz.Domain.DiscountAgg;

namespace TopTaz.Application.ContextACL
{
    public interface IDataBaseContext
    {
        DbSet<CatalogItem> CatalogItems { get; set; }
        DbSet<CatalogBrand> CatalogBrands { get; set; }
        DbSet<CatalogType> CatalogTypes { get; set; }
        DbSet<Basket> Baskets { get; set; }
        DbSet<BasketItem> BasketItems { get; set; }
        DbSet<UserAddress> UserAddresses { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderItem> OrderItems { get; set; }
        DbSet<Payment> Payments { get; set; }
        DbSet<Discount> Discounts { get; set; }

        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
