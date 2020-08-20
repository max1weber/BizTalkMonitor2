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
using BizTalk.Monitor.Web.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BizTalk.Monitor.Data.Context;
using System.Net.Http;
using BizTalk.Monitor.Client.Contracts;
using BizTalk.Monitor.Client;

namespace BizTalk.Monitor.Web
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

           
            services.AddTransient<HttpClient>(HttpClientFactory.Create);
            services.AddTransient<IApplicationsClient, ApplicationsClient>();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddDbContext<EsbExceptionDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("BizTalkConnection")));
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }


        public static class HttpClientFactory
        {
            public static HttpClient Create(IServiceProvider serviceProvider)
            {
                IConfiguration configuration = serviceProvider.GetRequiredService<IConfiguration>();
                var biztalkApiServiceBaseUrl = configuration.GetValue<string>("BiztalkApiServiceBaseUrl"); 
                var basicClient = new HttpClient(new HttpClientHandler() { UseDefaultCredentials = true }) { BaseAddress = new Uri(biztalkApiServiceBaseUrl) };

                return basicClient;
            }
        }
    }
}
