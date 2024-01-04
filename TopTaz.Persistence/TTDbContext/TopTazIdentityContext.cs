using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TopTaz.Domain.UserAgg;
using TopTaz.Infrastrure;

namespace TopTaz.Persistence.TTDbContext
{
    public class TopTazIdentityContext : IdentityDbContext<User>
    {

        public TopTazIdentityContext(DbContextOptions<TopTazIdentityContext> options)
            : base(options)
        {
        }



        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.AddAuditableProperties();
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("Identity");

        }

        public override int SaveChanges()
        {
            var helper = new EntityStateHelper(this);
            helper.TrackAndModifyEntities();
            return base.SaveChanges();
        }
    }
    
}
