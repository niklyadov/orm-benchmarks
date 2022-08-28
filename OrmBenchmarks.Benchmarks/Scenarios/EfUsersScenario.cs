using BenchmarkDotNet.Attributes;
using OrmBenchmarks.Benchmarks.Scenarios.Abstract;
using OrmBenchmarks.EF;
using OrmBenchmarks.EF.Repos;
using OrmBenchmarks.EF.Services;
using OrmBenchmarks.Entities;

namespace OrmBenchmarks.Benchmarks.Scenarios;

[BenchmarkCategory]
public class EfUsersScenario : BaseUserScenario
{
    public EfUsersScenario() : base(new UsersService(new UsersRepository(new EfApplicationContext())))
    {
    }
    
    [Benchmark]
    public override Task<User> AddRandomUserAsync()
    {
        return base.AddRandomUserAsync();
    }

    [Benchmark]
    public override Task<User> AddRandomUserAndDeleteAsync()
    {
        return base.AddRandomUserAndDeleteAsync();
    }

    [Benchmark]
    public override Task<User> AddRandomUserAndUpdateAsync()
    {
        return base.AddRandomUserAndUpdateAsync();
    }
    
    [Benchmark]
    public override Task<User> AddRandomUserAndDeleteAndRestoreAsync()
    {
        return base.AddRandomUserAndDeleteAndRestoreAsync();
    }

    [Benchmark]
    public override Task<User> AddRandomUserAndFindByIdAsync()
    {
        return base.AddRandomUserAndFindByIdAsync();
    }
}