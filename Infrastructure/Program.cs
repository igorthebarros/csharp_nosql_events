
using Infrastructure;
using Infrastructure.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder()
    .ConfigureServices((hostContext, services) =>
    {
        //services.AddTransient<>();
        services.AddScoped<IMongoContext, MongoContext>();
    }).UseConsoleLifetime();

var host = builder.Build();