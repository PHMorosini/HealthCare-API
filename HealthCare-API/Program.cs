
using HealthCare_API.Content.Cliente.Interfaces;
using HealthCare_API.Content.Cliente.Repository;
using HealthCare_API.Content.Cliente.Services;
using HealthCare_API.Content.ProblemaSaude.Interfaces;
using HealthCare_API.Content.ProblemaSaude.Repository;
using HealthCare_API.Content.ProblemaSaude.Services;
using HealthCare_API.Context;
using HealthCare_API.Mappers;
using Microsoft.EntityFrameworkCore;

namespace HealthCare_API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
        builder.Services.AddScoped<IProblemaSaudeRepository, ProblemaSaudeRepository>();
        builder.Services.AddScoped<IClienteService, ClienteService>();
        builder.Services.AddScoped<IProblemaSaudeService, ProblemaSaudeService>();

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        //Mappers
        builder.Services.AddAutoMapper(typeof(ClienteProfile).Assembly);

        //context ou AppDbContext,tnt faz
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
