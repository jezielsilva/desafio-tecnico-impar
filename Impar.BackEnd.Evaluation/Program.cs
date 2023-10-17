using Impar.BackEnd.Evaluation.Business.Implementation;
using Impar.BackEnd.Evaluation.Business.Interface;
using Impar.BackEnd.Evaluation.Repository.Context;
using Impar.BackEnd.Evaluation.Repository.Implementation;
using Impar.BackEnd.Evaluation.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddScoped<IMessagesBusiness, MessagesBusiness>();

        builder.Services.AddScoped<IMessageRepository, MessageRepository>();

        builder.Services.AddScoped<IUserBusiness, UserBusiness>();

        builder.Services.AddScoped<IUserRepository, UserRepository>();

        builder.Services.AddControllers();

        builder.Services.AddDbContext<MessagesDbContext>(options => 
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            options.UseSqlServer(connectionString, sqlServerOptions =>
            {
                sqlServerOptions.EnableRetryOnFailure();
            });
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}