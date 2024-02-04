using Microsoft.EntityFrameworkCore;
using TopTaz.Application.ContextACL;
using TopTaz.Domain.CatalogAgg;
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

        public DbSet<CatalogBrand>  CatalogBrands { get; set; }
        public DbSet<CatalogType> CatalogTypes { get; set; }


        #endregion



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assamble = typeof(CatalogBrandMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assamble);
            DataBaseContextSeed.CatalogSeed(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            var helper = new EntityStateHelper(this);
            helper.TrackAndModifyEntities();
            return base.SaveChanges();
        }



    }
}
