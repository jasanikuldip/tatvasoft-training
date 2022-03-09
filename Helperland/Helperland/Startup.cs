using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Helperland.Data;
using Helperland.Models;
using Helperland.IServices;
using Helperland.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace Helperland
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
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(options =>
                    {
                        options.LoginPath = "/Home/Index/1";
                        options.Cookie.Name = "Helperland_token";
                        //options.ExpireTimeSpan = System.TimeSpan.FromMinutes(1);
                    });
            services.AddControllersWithViews();
            services.AddDbContextPool<HelperlandContext>(o => o.UseSqlServer(Configuration.GetConnectionString("DefualtConnection")));
            services.AddScoped<IContactUsService,ContactUsService>();
            services.AddScoped<IUserService,UserService>();
            services.AddScoped<IEmailService,EmailService>();
            services.AddScoped<IUserAddressService,UserAddressService>();
            services.AddScoped<IServiceRequestService,ServiceRequestService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.Configure<SMTPConfigModel>(Configuration.GetSection("SMTPConfig"));
            //services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
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
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCookiePolicy();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
