using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TopTaz.Application.ContextACL;
using TopTaz.Domain.BasketAgg;
using TopTaz.Domain.CatalogAgg;
using TopTaz.Domain.FrameWorkDomain;
using TopTaz.Infrastrure;
using TopTaz.Infrastrure.Seeds;
using TopTaz.Persistence.Mapping.CatalogMap;

namespace TopTaz.Persistence.TTDbContext
{
    public class TopTazDbContext : DbContext, IDataBaseContext
    {
        public TopTazDbContext(DbContextOptions<TopTazDbContext> options) : base(options)
        {
        }


        #region Data Table

        public DbSet<CatalogBrand> CatalogBrands { get; set; }
        public DbSet<CatalogType> CatalogTypes { get; set; }
        public DbSet<CatalogItem> CatalogItems { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        #endregion



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (entityType.ClrType.GetCustomAttributes(typeof(AuditableAttribute), true).Length > 0)
                {
                    modelBuilder.Entity(entityType.Name).Property<DateTime>("InsertTime").HasDefaultValue(DateTime.Now);
                    modelBuilder.Entity(entityType.Name).Property<DateTime?>("UpdateTime");
                    modelBuilder.Entity(entityType.Name).Property<DateTime?>("RemoveTime");
                    modelBuilder.Entity(entityType.Name).Property<bool>("IsRemoved").HasDefaultValue(false);
                }
            }
            modelBuilder.Entity<CatalogType>()
                .HasQueryFilter(m => EF.Property<bool>(m, "IsRemoved") == false);
            modelBuilder.Entity<BasketItem>()
                .HasQueryFilter(m => EF.Property<bool>(m, "IsRemoved") == false);
            modelBuilder.Entity<Basket>()
                .HasQueryFilter(m => EF.Property<bool>(m, "IsRemoved") == false);

            var assamble = typeof(CatalogBrandMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assamble);
            DataBaseContextSeed.CatalogSeed(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

      

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(p => p.State == EntityState.Modified ||
                p.State == EntityState.Added ||
                p.State == EntityState.Deleted
                );
            foreach (var item in modifiedEntries)
            {
                var entityType = item.Context.Model.FindEntityType(item.Entity.GetType());

                var inserted = entityType.FindProperty("InsertTime");
                var updated = entityType.FindProperty("UpdateTime");
                var RemoveTime = entityType.FindProperty("RemoveTime");
                var IsRemoved = entityType.FindProperty("IsRemoved");
                if (item.State == EntityState.Added && inserted != null)
                {
                    item.Property("InsertTime").CurrentValue = DateTime.Now;
                }
                if (item.State == EntityState.Modified && updated != null)
                {
                    item.Property("UpdateTime").CurrentValue = DateTime.Now;
                }

                if (item.State == EntityState.Deleted && RemoveTime != null && IsRemoved != null)
                {
                    item.Property("RemoveTime").CurrentValue = DateTime.Now;
                    item.Property("IsRemoved").CurrentValue = true;
                    item.State = EntityState.Modified;
                }
            }
            return base.SaveChanges();
        }


    }
}

