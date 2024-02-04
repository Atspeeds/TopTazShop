using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using TopTaz.Persistence.TTDbContext;
using TopTaz.Application.ReportsService.VisitorReports;
using TopTaz.Application.VisitorApplication.VisitorOnline;
using TopTaz.Application.VisitorApplication.Visitors;
using AutoMapper;
using TopTaz.Infrastrure.AutoMapProfile;
using TopTaz.Application.CatalogApplication.CatalogTypes;

namespace TopTaz.Infrastrure.Config
{
    public class TopTazBoostraper
    {
        public static void Configuration(IServiceCollection services,string connectionString)
        {
            services.AddTransient<IVisitorOnlineApplication, VisitorOnlineApplication>();
            services.AddTransient<IVisitorApplication, VisitorApplication>();


            
            #region AutoMapperProfile
            services.AddAutoMapper(typeof(CatalogMapProfile));
            #endregion

            services.AddDbContext<TopTazDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });


        }

    }
}
