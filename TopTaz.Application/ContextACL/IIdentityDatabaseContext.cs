using Microsoft.EntityFrameworkCore;
using TopTaz.Domain.UserAgg;

namespace TopTaz.Application.ContextACL
{
    public interface IIdentityDatabaseContext
    {
        DbSet<User> Users { get; set; }
    }
}
