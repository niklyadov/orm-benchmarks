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
        var migrationService = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

        migrationService.ListMigrations();
        migrationService.MigrateUp(202106280001);
        
        return host;
    }
}