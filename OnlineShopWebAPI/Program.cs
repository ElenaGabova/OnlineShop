using Database;
using Database.Repository;
using Database.Service;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OnlineShopWebAPI;
using OnlineShopWebAPI.Middleware;
using Service;
using Service.Repository;
using System.Text;

public class Program
{

    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var configuration = builder.Configuration;
        string connection = configuration.GetConnectionString("DefaultConnection");

        //object p = builder.Services.AddControllers().AddNewtonsoftJson(options =>
        //options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        //); // добавляем, чтобы не было ошибки с сериализацией ссылочных моделей

        builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connection));
        builder.Services.AddDbContext<IdentityContext>(options => options.UseSqlServer(connection));
        builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<IdentityContext>();

        builder.Services.AddTransient<IProductBase, ProductsDbRepository>();
        builder.Services.AddTransient<IStoragesBase, StoragesDbRepository>();
        builder.Services.AddTransient<IOrdersBase, OrdersDbRepository>();
        builder.Services.AddTransient<IProductsService, ProductsRepository>();
        builder.Services.AddTransient<IStoragesService, StoragesRepository>();
        builder.Services.AddTransient<IOrdersService, OrdersRepository>();

        builder.Services.AddTransient<Service.IUserService, UserService>();
        builder.Services.AddHttpContextAccessor();





        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Online shop API",
                Description = "Online shop ASP.NET Core Web API"
            });


            // включаем авторизацию с помощью Swagger (JWT)
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                    }
                });
        });


        //builder.Services.AddAuthentication(options =>
        //{
        //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        //}).AddJwtBearer(options =>
        //{
        //    options.TokenValidationParameters = new TokenValidationParameters
        //    {
        //        ValidateIssuer = true,
        //        ValidateAudience = true,
        //        ValidateLifetime = true,
        //        ValidateIssuerSigningKey = true,
        //        ValidIssuer = configuration["Jwt:Issuer"],
        //        ValidAudience = configuration["Jwt:Audience"],
        //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
        //    };
        //});

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();
        app.UseMiddleware<JWTMiddleware>();


        app.MapControllers();

        app.Run();
    }
}