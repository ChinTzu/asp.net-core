using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SportsRetail.Data;
using SportsRetail.Data.Interfaces;
using SportsRetail.Data.Mocks;
using SportsRetail.Data.Models;
using SportsRetail.Data.Repositories;

namespace SportsRetail
{
    public class Startup
    {
        private IConfigurationRoot _configurationRoot;

        public Startup(IHostingEnvironment hostingEnvironment)
        {
            _configurationRoot = new ConfigurationBuilder()
                .SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddTransient<IProductRepository, MockProductRepository>();
            //services.AddTransient<ICategoryRepository, MockCategoryRepository>();

            //Server configuration
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(_configurationRoot.GetConnectionString("DefaultConnection")));

            //Authentication, Identity config
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();

            //services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddScoped(sp => ShoppingCart.GetCart(sp));

            services.AddTransient<IOrderRepository, OrderRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env,  ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "categoryPage", template: "Product/{action}/{category}/Page{productPage:int}",
                    defaults: new { controller = "Product", action = "List" });

                routes.MapRoute(name: "category", template: "Product/{action}/{category?}",
                    defaults: new { controller = "Product", action = "List"});

                routes.MapRoute( name: "Page", template: "Product/{action}/Page{productPage:int}",
                    defaults: new { controller = "Product", action = "List", productPage = 1});

                //show customers preferred products as default index at home page 
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{Id?}");
            });
            
            DbInitializer.Seed(app);
        }
    }
}
