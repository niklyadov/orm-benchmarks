using FluentMigrator.Runner;
using OrmBenchmarks.Dapper.Migrations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace OrmBenchmarks.Dapper.Extensions;

public static class MigrationManager
{
    public static IHost MigrateDatabase(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        var databaseService = scope.ServiceProvider.GetRequiredService<Database>();
        var migrationService = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

        try
        {
            databaseService.CreateDatabase("");

            migrationService.ListMigrations();
            migrationService.MigrateUp(202106280001);

        }
        catch
        {
            //log errors or ...
            throw;
        }

        return host;
    }
}