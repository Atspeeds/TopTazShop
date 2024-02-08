using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TopTaz.Application.CatalogApplication.CatalogItems;
using TopTaz.Application.CatalogApplication.CatalogQuery;
using TopTaz.Application.CatalogApplication.CatalogTypes;
using TopTaz.Application.ContextACL;
using TopTaz.Application.ReportsService.VisitorReports;
using TopTaz.Infrastrure.ExternalApi.ImageServer;
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
            services.AddTransient<ICatalogItemApplication,CatalogItemApplication>();

            services.AddTransient<ICatalogTypeQuery, CatalogTypeQuery>();
            services.AddTransient<ICatalogItemQuery, CatalogItemQuery>();

            services.AddTransient<IImageUploadService, ImageUploadService>();
            services.AddDbContext<TopTazDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            
        }

    }
}
