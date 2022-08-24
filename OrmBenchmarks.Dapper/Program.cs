using System.Reflection;
using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrmBenchmarks.Dapper.Extensions;
using OrmBenchmarks.Dapper.Migrations;
namespace OrmBenchmarks.Dapper;

public class Program
{
    public static void Main(string[] args)
    {
        var hostBuilder = Host.CreateDefaultBuilder(args);

        hostBuilder.ConfigureServices((hostContext, services) =>
        {
            services.AddSingleton<ApplicationContext>();
            services.AddSingleton<Database>();

            services.AddLogging(c => c.AddFluentMigratorConsole())
                .AddFluentMigratorCore()
                .ConfigureRunner(c => c.AddSQLite()
                    .WithGlobalConnectionString(hostContext.Configuration.GetConnectionString("MasterConnection"))
                    .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations());
        });
        
        var host = hostBuilder.Build();
        host.MigrateDatabase();
        //host.Run();
    }
}