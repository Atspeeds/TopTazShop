using Microsoft.EntityFrameworkCore;
using TopTaz.Application.ContextACL;
using TopTaz.Domain.UserAgg;
using TopTaz.Infrastrure;


namespace TopTaz.Persistence.TTDbContext
{
    public class TopTazDbContext : DbContext, IDataBaseContext
    {
        public TopTazDbContext(DbContextOptions<TopTazDbContext> options) : base(options)
        {
        }


        #region Data Table
  
        #endregion



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
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
