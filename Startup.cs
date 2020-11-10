using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using storeAdmin.Models;

namespace storeAdmin
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
            services.AddControllersWithViews();
            services.AddCors(); 
                services.AddDbContext<AllBuyUserContext>(options =>

                  options.UseSqlServer(Configuration.GetConnectionString("contactContext")));
            services.AddDbContext<AllBuyContext>(options =>

                  options.UseSqlServer(Configuration.GetConnectionString("contactContext")));
            services.AddDbContext<OrdersDetailsContext>(options =>

                  options.UseSqlServer(Configuration.GetConnectionString("contactContext")));
            services.AddDbContext<OrdersContext>(options =>

                  options.UseSqlServer(Configuration.GetConnectionString("contactContext")));
            services.AddDbContext<CustomersContext>(options =>

                  options.UseSqlServer(Configuration.GetConnectionString("contactContext")));
           
            services.AddDbContext<ProApiContext>(options =>

                  options.UseSqlServer(Configuration.GetConnectionString("contactContext")));

            services.AddDbContext<ProductContext>(options =>

                  options.UseSqlServer(Configuration.GetConnectionString("contactContext")));
            services.AddDbContext<CategoriesContext>(options =>

                  options.UseSqlServer(Configuration.GetConnectionString("contactContext")));
            services.AddDbContext<CatApiContext>(options =>

                  options.UseSqlServer(Configuration.GetConnectionString("contactContext")));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.  
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddDistributedMemoryCache();
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromDays(150);//You can set Time   
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
            app.UseCors(builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed((host) => true)
                .AllowCredentials()
            );
            app.UseCookiePolicy();
            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
