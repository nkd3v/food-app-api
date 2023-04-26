using FoodAppAPI.Models;
using FoodAppAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System.Text;

namespace FoodAppAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.Configure<MenuDatabaseSettings>(builder.Configuration.GetSection("FoodAppDatabaseSettings"));
            builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("FoodAppDatabaseSettings"));
            builder.Services.AddSingleton<IMenuDatabaseSettings>(provider => provider.GetRequiredService<IOptions<MenuDatabaseSettings>>().Value);
            builder.Services.AddSingleton<IDatabaseSettings>(provider => provider.GetRequiredService<IOptions<DatabaseSettings>>().Value);
            builder.Services.AddSingleton<IMongoClient>(provider => new MongoClient(builder.Configuration.GetValue<string>("FoodAppDatabaseSettings:ConnectionString")));

            builder.Services.AddScoped<IMenuService, MenuService>();
            builder.Services.AddScoped<IOrderService, OrderService>();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true
                };
            });

            builder.Services.AddAuthorization();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseRouting();

            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
            });

            app.MapControllers();

            app.Run();
        }
    }
}