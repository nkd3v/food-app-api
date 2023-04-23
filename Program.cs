using FoodAppAPI.Models;
using FoodAppAPI.Models.Interfaces;
using FoodAppAPI.Services;
using FoodAppAPI.Services.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FoodAppAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.Configure<MenuDatabaseSettings>(builder.Configuration.GetSection("FoodAppDatabaseSettings"));
            builder.Services.AddSingleton<IMenuDatabaseSettings>(sp => sp.GetRequiredService<IOptions<MenuDatabaseSettings>>().Value);
            builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("FoodAppDatabaseSettings:ConnectionString")));
            builder.Services.AddScoped<IMenuService, MenuService>();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();

            app.UseAuthorization();

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