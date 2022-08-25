using System.Reflection;
using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrmBenchmarks.Dapper.Extensions;
using OrmBenchmarks.Dapper.Migrations;
using OrmBenchmarks.Dapper.Repos;
using OrmBenchmarks.Dapper.Services;

namespace OrmBenchmarks.Dapper;

public class Program
{
    public static void Main(string[] args)
    {
        var hostBuilder = Host.CreateDefaultBuilder(args);

        hostBuilder.ConfigureServices((hostContext, services) =>
        {
            services.AddSingleton<DapperApplicationContext>();

            services.AddSingleton<UsersRepository>();
            services.AddSingleton<UsersService>();
            
            services.AddLogging(c => c.AddFluentMigratorConsole())
                .AddFluentMigratorCore()
                .ConfigureRunner(c => c.AddSQLite()
                    .WithGlobalConnectionString(DapperApplicationContext.ConnectionString)
                    .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations());
        });
        
        var host = hostBuilder.Build();
        host.MigrateDatabase();
    }
}