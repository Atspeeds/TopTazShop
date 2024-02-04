using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TopTaz.Application.CatalogApplication.CatalogTypes;
using TopTaz.Application.ContextACL;
using TopTaz.Application.ReportsService.VisitorReports;
using TopTaz.Application.VisitorApplication.VisitorOnline;
using TopTaz.Application.VisitorApplication.Visitors;
using TopTaz.Infrastrure.AutoMapProfile;
using TopTaz.Persistence.TTDbContext;

namespace TopTaz.Infrastrure.Config
{
    public class TopTazAdminBootstraper
    {
        public static void Configuration(IServiceCollection services, string connectionString)
        {

            services.AddTransient<IVisitorReport, VisitorReport>();
            services.AddTransient(typeof(IMongoServiceConnection<>), typeof(TopTazMongoDbContext<>));
            services.AddTransient<ICatalogTypeApplication, CatalogTypeApplication>();
            services.AddTransient<IDataBaseContext,TopTazDbContext>();

           

            services.AddDbContext<TopTazDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            
        }

    }
}
