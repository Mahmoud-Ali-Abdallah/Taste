using Blazored.Toast;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net.Http;
using Taste.UIServices.IServices;
using Taste.UIServices.IServices.Admin;
using Taste.UIServices.IServices.LocalStorage;
using Taste.UIServices.Services;
using Taste.UIServices.Services.Admin;
using Taste.UIServices.Services.LocalStorage;

namespace Taste.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddHttpContextAccessor();
            services.AddBlazoredToast();

            services.AddAuthentication("Taste.CookieAuth")
                .AddCookie("Taste.CookieAuth", config =>
                {
                    config.Cookie.Name = "Taste.CookieAuth";
                    config.LoginPath = "/authenticate";

                });


            #region  Inject custom Services
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IFoodTypeService, FoodTypeService>();
            services.AddScoped<IMenuItemService, MenuItemService>();
            services.AddScoped<IUserService, UserService>();
            #endregion

            #region Inject LocalStorage Services
            services.AddScoped<ILocalStorageService, LocalStorageService>();
            #endregion

            services.AddSingleton<HttpClient, HttpClient>(
                x =>
                {
                    return new HttpClient
                    {
                        BaseAddress = new Uri("https://localhost:44315/api/")
                    };
                });

            #region Another way to inject HttpClient
            //services.AddHttpClient<HttpClient, HttpClient>(
            //    x =>
            //    {
            //        return new HttpClient
            //        {
            //            BaseAddress = new Uri("https://localhost:44315/api/")
            //        };
            //    });
            #endregion


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
                app.UseExceptionHandler("/Error");
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
