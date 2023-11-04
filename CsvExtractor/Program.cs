// See https://aka.ms/new-console-template for more information
using CsvExtractor.Services;
using CsvExtractor.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File(@"C:\Users\hankh\dev\MaddenMobileCSVFiles\Logs\PlayerLoad_.log",
        rollingInterval: RollingInterval.Day,
        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
    .CreateLogger();

var host = Host.CreateDefaultBuilder(args)
    .UseSerilog()
    .ConfigureServices((hostContext, services) =>
    {
        services.AddSingleton<ILogger<LoadDataService>, Logger<LoadDataService>>();
        services.AddSingleton<ICsvService, CsvService>();
        services.AddSingleton<IDbService, DbService>();
        services.AddSingleton<IFileService, FileService>();
        services.AddSingleton<ILoadDataService, LoadDataService>();
    })
    .Build();

Execute(host.Services);

static void Execute(IServiceProvider hostProvider)
{
    using IServiceScope scope = hostProvider.CreateScope();
    IServiceProvider provider = scope.ServiceProvider;
    ILoadDataService loadDataService = provider.GetRequiredService<ILoadDataService>();
    loadDataService.LoadData();
}
