using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopTaz.Application.ContextACL;
using TopTaz.Domain.UserAgg;

namespace TopTaz.Persistence.TTDbContext
{
    public class TopTazDbContext : DbContext, IDataBaseContext
    {
        public TopTazDbContext(DbContextOptions<TopTazDbContext> options):base(options)
        {
        }


        #region Data Table
        public DbSet<User> Users { get; set; }
        #endregion




    }
}
