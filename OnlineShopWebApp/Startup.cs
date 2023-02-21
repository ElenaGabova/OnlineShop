using System;
using System.Globalization;
using Database;
using Database.Repository;
using Database.Service;
using Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Mappers;
using Serilog;
using Service;
using Service.Repository;
using Microsoft.AspNetCore.Http;
using DatabaseProject.Services;

namespace Domain
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

            //   var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
            //   var dbName = Environment.GetEnvironmentVariable("DB_NAME");
            //   var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
            //Add database connection
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(connection);
            });
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddHttpContextAccessor();
            services.AddDbContext<IdentityContext>(options =>
             {
                 options.UseSqlServer(connection);
             } );

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>();

            //настройка кук
            services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromHours(8);
                options.LoginPath = "/Autorization/Account/Login";
                options.LogoutPath = "/Autorization/Account/Logout";
                options.Cookie = new Microsoft.AspNetCore.Http.CookieBuilder
                {
                    IsEssential = true
                };
            });


            services.AddHttpsRedirection(options =>
            {
                options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
                options.HttpsPort = 44344;
            });

            services.AddControllersWithViews();
            ///Add services
            services.AddTransient<IProductBase, ProductsDbRepository>();       
            services.AddTransient<IStoragesBase, StoragesDbRepository>(); 
            services.AddTransient<IFavoriteProductsBase, FavoriteProductsDbRepository>();
            services.AddTransient<IUserDeliveryInfoBase, UsersDeliveryInfoDbRepository>();
            services.AddTransient<IOrdersBase, OrdersDbRepository>();
            services.AddTransient<ITextPageBase, TextPagesDbRepository>();
            services.AddTransient<IDirectionBase, DanceDirectionDbRepository>();
            services.AddTransient<IDanceDirectionRegistrationBase, DanceDirectionRegistrationDbRepository>();
            services.AddTransient<IDirectionUserBase, DanceDirectionUserDbRepository>();


            services.AddTransient<IProductsService, ProductsRepository>();
            services.AddTransient<IStoragesService, StoragesRepository>();
            services.AddTransient<IFavoriteProductsService, FavoriteProductsRepository>();
            services.AddTransient<IUserDeliveryInfoService, UsersDeliveryInfoRepository>();
            services.AddTransient<IOrdersService, OrdersRepository>();
            services.AddTransient<ITextPageService, TextPagesRepository>();
            services.AddTransient<IDanceDirectionService, DanceDirectionRepository>();
            services.AddTransient<IDanceDirectionRegistrationService, DanceDirectionRegistrationRepository>();
            services.AddTransient<IDanceDirectionUserService, DanceDirectionUserRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRequestLocalization();

            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");

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
            //Cache images from wwwroot
            app.UseStaticFiles(new StaticFileOptions()
            {
                OnPrepareResponse = ctx =>
                {
                    ctx.Context.Response.Headers.Add("Cache-Control", "public,max-age=600");
                }
            });

            //Add serialog endpoint
            app.UseSerilogRequestLogging();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            //Подключение аутентификации
            app.UseAuthentication();
            //Подключение авторизации
            app.UseAuthorization();
            //Переадресация по https
            app.UseHttpsRedirection();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "MyArea",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

    }
}
