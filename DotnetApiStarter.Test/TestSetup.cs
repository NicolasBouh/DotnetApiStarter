using System.IO;
using DotnetApiStarter.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace DotnetApiStarter.Test;

[SetUpFixture]
public class TestSetup
{
    private static IConfigurationRoot _configuration = null!;
    private static IServiceScopeFactory _scopeFactory = null!;
    private static int? _currentUserId;
    
    [OneTimeSetUp]
    public void RunBeforeAnyTests()
    {
        var builder = new ConfigurationBuilder()!;
        builder.set
        
        _configuration = builder.Build();
        
        _scopeFactory = services.BuildServiceProvider().GetRequiredService<IServiceScopeFactory>();
    }

    private static void EnsureDatabase()
    {
        using var scope = _scopeFactory.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        context.Database.Migrate();
    }
}