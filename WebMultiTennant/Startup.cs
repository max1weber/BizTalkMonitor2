using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using WebMultiTennant.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Finbuckle.MultiTenant;
using Microsoft.Extensions.Options;

namespace WebMultiTennant
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

          

            services.AddDbContext<TenantDbContext>(optionsTenant=> {

                optionsTenant.UseSqlServer(Configuration.GetConnectionString("TenantConnection"));
            });

            services.AddDbContext<TenantDbContext>(options =>
                    options.UseSqlServer(
                    Configuration.GetConnectionString("TenantConnection")));

            services.AddMultiTenant().WithRouteStrategy().WithEFCoreStore<TenantDbContext>().WithFallbackStrategy("defaultTenant"); ;
           services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseMultiTenant();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{__tenant__}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            this.SetupStore(app.ApplicationServices);
        }


        private void SetupStore(IServiceProvider sp)
        {
            var scopeServices = sp.CreateScope().ServiceProvider;
            var store = scopeServices.GetRequiredService<IMultiTenantStore>();

            store.TryAddAsync(new TenantInfo("defaultTenant", "defaultTenant", "Default", "DefaultConnection", null)).Wait();
          //  store.TryAddAsync(new TenantInfo("tenant-initech-341ojadsfa", "initech", "Initech LLC", "initech_conn_string", null)).Wait();
        }
    }
}
