using OrmBenchmarks.Benchmarks.Scenarios.Abstract;
using OrmBenchmarks.Dapper;
using OrmBenchmarks.Dapper.Repos;
using OrmBenchmarks.Dapper.Services;

namespace OrmBenchmarks.Benchmarks.Scenarios;

public class DapperUsersScenario : BaseUserScenario
{
    public DapperUsersScenario() : base(new UsersService(new UsersRepository(new DapperApplicationContext())))
    {
    }

    public async Task DoAsync()
    {
        await AddRandomUserAsync();
        await AddRandomUserAndDeleteAsync();
        await AddRandomUserAndUpdateAsync();
        await AddRandomUserAndDeleteAndRestoreAsync();
        await AddRandomUserAndFindByIdAsync();
    }
}