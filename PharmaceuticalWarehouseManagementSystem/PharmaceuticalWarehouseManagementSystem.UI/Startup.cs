using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing.Matching;
using Microsoft.AspNetCore.Server.IIS;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using PharmaceuticalWarehouseManagementSystem.DAL.Context;
using PharmaceuticalWarehouseManagementSystem.INFRASTRUCTURE.Repository.Abstract;
using PharmaceuticalWarehouseManagementSystem.INFRASTRUCTURE.Repository.Concrete;
using PharmaceuticalWarehouseManagementSystem.KERNEL;
using PharmaceuticalWarehouseManagementSystem.UI.Models;

namespace PharmaceuticalWarehouseManagementSystem.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            
        }
        //InvalidOperationException: No authenticationScheme was specified, and there was no DefaultChallengeScheme found. The default schemes can be set using either AddAuthentication(string defaultScheme) or AddAuthentication(Action<AuthenticationOptions> configureOptions).

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddAuthentication("CookieAuth").AddCookie("CookieAuth",config=>
            //{
            //    config.Cookie.Name = "Grandmas.Cookie";
            //});
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddMvc().AddXmlDataContractSerializerFormatters();
  
            services.AddDbContext<ProjectContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ICategoryRepository, EfCategory>();
            services.AddScoped<ICustomerRepository, EfCustomer>();
            services.AddScoped<IEmployeeRepository, EfEmployee>();
            services.AddScoped<IOrderDetailRepository, EfOrderDetail>();
            services.AddScoped<IOrderRepository, EfOrder>();
            services.AddScoped<IProductRepository, EfProduct>();
            services.AddScoped<IShipperRepository, EfShipper>();
            services.AddScoped<ISupplierRepository, EfSupplier>();

            services.AddIdentity<IdentityUser, IdentityRole>(options=>
                {
                    options.SignIn.RequireConfirmedEmail = true;
                    
                })
                .AddEntityFrameworkStores<ProjectContext>()
                .AddDefaultTokenProviders();

            services.Configure<PasswordHasherOptions>(options =>
                {
                    options.CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV2;
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
            }
            app.UseStaticFiles();

  

            app.UseRouting();
            app.UseAuthorization();
            
            
            app.UseEndpoints(endpoints =>
            {
           

                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");

                endpoints.MapRazorPages();
            });
        }
    }
}
