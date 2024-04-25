
using OnionArchitectureOgrenme.Application;
using OnionArchitectureOgrenme.Application.Abstrtaction.Services;
using OnionArchitectureOgrenme.Application.Abstrtaction.Services.Concrete;
using OnionArchitectureOgrenme.Presistence;
using OnionArchitectureOgrenme.Infrastructure;
using OnionArchitectureOgrenme.Presistence.Services;

namespace OnionArchitectureOgrenme.API
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

            builder.Services.AddPersistneceServices();
            builder.Services.AddApplicationServices();
            builder.Services.AddInfrastructureServices();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
