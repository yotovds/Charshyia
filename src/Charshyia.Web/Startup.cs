using AutoMapper;
using Charshyia.Data;
using Charshyia.Data.Models;
using Charshyia.Services;
using Charshyia.Services.Contracts;
using Charshyia.Services.Models;
using Charshyia.Services.Models.Orders;
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

            services.AddAntiforgery();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Identity/Account/Login";
                //options.LogoutPath = $"/Identity/Account/Logout";
                //options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
            });

            // TODO: Extract to file, and use reflection and interfaces
            services.AddAutoMapper(configuration =>
            {
                configuration.CreateMap<ProductCreateInputModel, Product>();
                configuration.CreateMap<Product, ProductDetailsViewModel>();
                configuration.CreateMap<ProductDetailsViewModel, Product>();

                configuration.CreateMap<ShopCreateInputModel, Shop>();
                configuration.CreateMap<Shop, ShopDetailsViewModel>();
                configuration.CreateMap<ShopDetailsViewModel, Shop>();
                configuration.CreateMap<ShopUser, ShopDetailsViewModel>();

                configuration.CreateMap<UserDetailsViewModel, CharshyiaUser>();
                configuration.CreateMap<CharshyiaUser, UserDetailsViewModel>();

                configuration.CreateMap<ShopProduct, ProductDetailsViewModel>();
                configuration.CreateMap<ProductDetailsViewModel, ShopProduct>();

                configuration.CreateMap<UserDetailsViewModel, ShopUser>();
                configuration.CreateMap<ShopUser, UserDetailsViewModel>();

                configuration.CreateMap<ShopProduct, ShopDetailsViewModel>();

                configuration.CreateMap<Order, OrderDetailsViewModel>();
                configuration.CreateMap<OrderDetailsViewModel, Order>();
            });

            // My services
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IShopService, ShopService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPartnershipService, PartnershipService>();
            services.AddScoped<ICommnetService, CommnetService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ISearchService, SearchService>();
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

                routes.MapRoute(
                    name: "area",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            });

            // Add roles
            this.CreateUserRoles(services).GetAwaiter().GetResult();
            //this.SeedData(services);
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
                await RoleManager.CreateAsync(new IdentityRole("Producer"));
            }

            //Assign Admin role to the main User here we have given our newly registered 
            //login id for Admin management
            //CharshyiaUser user = await UserManager.FindByEmailAsync("syedshanumcain@gmail.com");
            //var User = new CharshyiaUser();
            //await UserManager.AddToRoleAsync(user, "Admin");
        }

        //private void SeedData(IServiceProvider services)
        //{
        //    var db = services.GetService<CharshyiaDbContext>();
        //    var userManager = services.GetService<UserManager<CharshyiaUser>>();

        //    if (db.Users.CountAsync().GetAwaiter().GetResult() == 0)
        //    {
        //        string[] userNames = { "Ivan", "Dragan", "Pesho", "Ju", "Minka" };

        //        for (int i = 0; i < userNames.Length; i++)
        //        {
        //            var userProducer = new CharshyiaUser
        //            {
        //                UserName = userNames[i],
        //                Email = userNames[i] + "@mail.bg",
        //                PhoneNumber = "08966600" + i
        //            };

        //            userManager.CreateAsync(userProducer, "123").GetAwaiter().GetResult();
        //            userManager.AddToRoleAsync(userProducer, "Producer").GetAwaiter().GetResult();

        //            for (int j = 0; j < 10; j++)
        //            {
        //                var product = new Product
        //                {
        //                    Name = userProducer.UserName + "Product" + j,
        //                    Price = new Random().Next(5, 1000),
        //                    Description = "DescriptionDescriptionDescription",
        //                    ProducerId = userProducer.Id,
        //                    ImageUrl = "https://res.cloudinary.com/dr8axwivq/image/upload/v1546794753/test.jpg"
        //            };

        //                db.Products.Add(product);
        //            }
        //            db.SaveChanges();

        //            var user = new CharshyiaUser
        //            {
        //                UserName =  userNames[i] + i,
        //                Email = userNames[i] + "@mail.bg",
        //                PhoneNumber = "08966600" + i
        //            };

        //            userManager.CreateAsync(user, "123").GetAwaiter().GetResult();
        //            userManager.AddToRoleAsync(user, "User").GetAwaiter().GetResult();
        //        }
        //    }           
        //}
    }
}
