using DotnetApiStarter.Api.Extensions;
using DotnetApiStarter.Application;
using DotnetApiStarter.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApiServices(builder);

var app = builder.Build();

app.ConfigureApplication();

app.InitializeData();

app.Run();