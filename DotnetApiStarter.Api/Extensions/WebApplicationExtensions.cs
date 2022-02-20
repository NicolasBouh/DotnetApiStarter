using DotnetApiStarter.Api.Middlewares;
using DotnetApiStarter.Application.Interfaces;

namespace DotnetApiStarter.Api.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication ConfigureApplication(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        
        app.UseCors("DefaultPolicy");

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.UseMiddleware<ExceptionHandlerMiddleware>();

        app.MapControllers();

        return app;
    }

    public static WebApplication InitializeData(this WebApplication app)
    {
        var scopefactory = app.Services.GetService<IServiceScopeFactory>();

        var scope = scopefactory?.CreateScope();

        var service = scope?.ServiceProvider.GetService<IDataInitializer>();
        service?.Initialize();

        return app;
    }
}