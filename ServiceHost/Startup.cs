using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServiceHost.Hubs;
using ServiceHost.Utility.Filters;
using ServiceHost.Utility.Middleware;
using System;
using TopTaz.Application.ContextACL;
using TopTaz.Application.VisitorApplication.Visitors;
using TopTaz.Infrastrure.Config;
using TopTaz.Persistence.TTDbContext;

namespace ServiceHost
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string ConnectionString = Configuration.GetConnectionString("SqlServer");
            services.AddSignalR();

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(RegisterVisitFilter));
            });

            TopTazBoostraper.Configuration(services, ConnectionString);
            TopTazIdentityBootstraper.Configuration(services, ConnectionString);
            services.AddTransient(typeof(IMongoServiceConnection<>), typeof(TopTazMongoDbContext<>));
            
           

            services.AddAuthorization();

            services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromMinutes(160);
                options.SlidingExpiration = true;
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseVisitorsIdRegistration();
            app.UseRouting();

           
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapHub<OnlineVisitorHub>("/chathub");
            });
        }
    }
}
