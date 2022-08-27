using OrmBenchmarks.Benchmarks.Scenarios.Abstract;
using OrmBenchmarks.EF;
using OrmBenchmarks.EF.Repos;
using OrmBenchmarks.EF.Services;

namespace OrmBenchmarks.Benchmarks.Scenarios;

public class EfUsersScenario : BaseUserScenario
{
    public EfUsersScenario() : base(new UsersService(new UsersRepository(new EfApplicationContext())))
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