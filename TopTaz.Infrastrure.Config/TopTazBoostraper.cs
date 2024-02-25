using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using TopTaz.Persistence.TTDbContext;
using TopTaz.Application.VisitorApplication.VisitorOnline;
using TopTaz.Application.VisitorApplication.Visitors;
using AutoMapper;
using TopTaz.Infrastrure.AutoMapProfile;
using TopTaz.Application.CatalogApplication.CatalogQuery;
using TopTaz.Application.ContextACL;
using TopTaz.Application.BasketApplication.BasketQuery;
using TopTaz.Application.UsersApplication;
using TT.FrameWork.Application.UriComposer;
using TopTaz.Application.OrderApplication;

namespace TopTaz.Infrastrure.Config
{
    public class TopTazBoostraper
    {
        public static void Configuration(IServiceCollection services,string connectionString)
        {
            services.AddTransient<IVisitorOnlineApplication, VisitorOnlineApplication>();
            services.AddTransient<IVisitorApplication, VisitorApplication>();
            services.AddTransient<IUserAddressApplication, UserAddressApplication>();
            services.AddTransient<IOrderApplication, OrderApplication>();


            //===========================================================
            services.AddTransient<ICatalogTypeQuery, CatalogTypeQuery>();
            services.AddTransient<IDataBaseContext, TopTazDbContext>();
            services.AddTransient<ICatalogItemQuery, CatalogItemQuery>();
            services.AddTransient<IBasketQuery, BasketQuery>();

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
