using DesafioCnab.Domain.Interfaces.Services;
using DesafioCnab.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


//# nullable disable
var host = CreateHostBuilder(args).Build();
Application app = host.Services.GetRequiredService<Application>();


var fileService = host.Services.GetRequiredService<IFileService>();

var stream = File.OpenRead("C:\\Users\\Zack\\Repository\\desafio-dev\\CNAB.txt");

await fileService.ProcessarArquivo(stream);

static IHostBuilder CreateHostBuilder(string[] args)
{
return Host.CreateDefaultBuilder(args)
    .ConfigureServices(
        (_, services) => services
            .AddTransient<IFileService, FileService>()
            .AddSingleton<Application, Application>()
            .AddSingleton<IAppConfig, AppConfig>());
}

interface IAppConfig
{
    string Setting { get; }
}

class AppConfig : IAppConfig
{
    public string Setting { get; }
    public AppConfig() => Console.WriteLine("AppConfig constructed");
}

class Application
{
    private readonly IAppConfig config;
    public Application(IAppConfig config, ILogger<Application> logger)
    {
        this.config = config;
        logger.Log(LogLevel.Information, "Application constructed");
    }
}