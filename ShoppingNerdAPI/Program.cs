
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ShoppingNerdAPI.Config;
using ShoppingNerdAPI.Model.Context;
using ShoppingNerdAPI.Repository;
using ShoppingNerdAPI.Repository.Interfaces;

namespace ShoppingNerdAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
     

             builder.Services.AddDbContext<MysqlContext>(options =>
             options.UseMySql(builder.Configuration.GetConnectionString("MysqlContext"),new MySqlServerVersion(new Version(8,0,5))));
             IMapper mapper = MappingConfig.RegistroMaps().CreateMapper();
             builder.Services.AddSingleton(mapper);
             builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
             builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}