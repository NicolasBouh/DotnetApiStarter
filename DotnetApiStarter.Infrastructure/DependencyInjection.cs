using DotnetApiStarter.Application.Interfaces;
using DotnetApiStarter.Infrastructure.Data;
using DotnetApiStarter.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DotnetApiStarter.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ITokenService, TokenService>();

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
        });
        services.AddScoped<IAppDbContext>(provider => provider.GetRequiredService<AppDbContext>());
        
        services.AddTransient<IDataInitializer, DataInitializer>();
    }
}