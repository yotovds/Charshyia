using AutoMapper;
using Charshyia.Data;
using Charshyia.Data.Models;
using Charshyia.Services;
using Charshyia.Services.Contracts;
using Charshyia.Services.Models;
using Charshyia.Services.Models.Products;
using Charshyia.Services.Models.Shops;
using Charshyia.Services.Models.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Charshyia.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<CharshyiaDbContext>(options =>
                    options.UseSqlServer(
                        this.Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<CharshyiaUser, IdentityRole>()
                    .AddEntityFrameworkStores<CharshyiaDbContext>()
                    .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.SignIn.RequireConfirmedEmail = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 3;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // TODO: Extract to file, and use reflection and interfaces
            services.AddAutoMapper(configuration =>
            {
                configuration.CreateMap<ProductCreateInputModel, Product>();
                configuration.CreateMap<Product, ProductDetailsViewModel>();

                configuration.CreateMap<ShopCreateInputModel, Shop>();
                configuration.CreateMap<Shop, ShopDetailsViewModel>();

                configuration.CreateMap<UserDetailsViewModel, CharshyiaUser>();
                configuration.CreateMap<CharshyiaUser, UserDetailsViewModel>();

            });

            // My services
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IShopService, ShopService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider services)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            // Add amin and user roles
            this.CreateUserRoles(services).GetAwaiter().GetResult();
        }

        private async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            //var UserManager = serviceProvider.GetRequiredService<UserManager<CharshyiaUser>>();

            //IdentityResult roleResult;
            //Adding Admin Role
            //var roleCheck = await RoleManager.RoleExistsAsync("Admin");
            if (await RoleManager.Roles.AnyAsync() == false)
            {
                //create the roles and seed them to the database
                await RoleManager.CreateAsync(new IdentityRole("Admin"));
                await RoleManager.CreateAsync(new IdentityRole("User"));
            }

            //Assign Admin role to the main User here we have given our newly registered 
            //login id for Admin management
            //CharshyiaUser user = await UserManager.FindByEmailAsync("syedshanumcain@gmail.com");
            //var User = new CharshyiaUser();
            //await UserManager.AddToRoleAsync(user, "Admin");
        }
    }
}
