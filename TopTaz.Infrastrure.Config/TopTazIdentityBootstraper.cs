using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TopTaz.Persistence.TTDbContext;
using Microsoft.AspNetCore.Identity;
using TopTaz.Domain.UserAgg;
using System;

namespace TopTaz.Infrastrure.Config
{
    public class TopTazIdentityBootstraper
    {
        public static void Configuration(IServiceCollection services, string connectionString)
        {


            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<TopTazIdentityContext>()
                .AddDefaultTokenProviders()
                .AddRoles<IdentityRole>()
                .AddErrorDescriber<CustomIdentityError>();

            services.Configure<IdentityOptions>(options =>
            {

                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 8;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequireNonAlphanumeric = false;
                options.User.RequireUniqueEmail = true;
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
            });

            services.AddDbContext<TopTazIdentityContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

        }
    }
}
