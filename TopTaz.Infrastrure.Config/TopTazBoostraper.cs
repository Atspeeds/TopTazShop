using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using TopTaz.Persistence.TTDbContext;

namespace TopTaz.Infrastrure.Config
{
    public class TopTazBoostraper
    {
        public static void Configuration(IServiceCollection services,string connectionString)
        {
            services.AddDbContext<TopTazDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }

    }
}
