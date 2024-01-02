using System.Threading.Tasks;
using System.Threading;
using TopTaz.Domain.UserAgg;
using Microsoft.EntityFrameworkCore;

namespace TopTaz.Application.ContextACL
{
    public interface IDataBaseContext
    {
        public DbSet<User> Users { get; set; }
        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
