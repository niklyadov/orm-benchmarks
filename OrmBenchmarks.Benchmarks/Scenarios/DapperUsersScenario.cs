using BenchmarkDotNet.Attributes;
using OrmBenchmarks.Benchmarks.Scenarios.Abstract;
using OrmBenchmarks.Dapper;
using OrmBenchmarks.Dapper.Repos;
using OrmBenchmarks.Dapper.Services;
using OrmBenchmarks.Entities;

namespace OrmBenchmarks.Benchmarks.Scenarios;

[BenchmarkCategory]
public class DapperUsersScenario : BaseUserScenario
{
    public DapperUsersScenario() : base(new UsersService(new UsersRepository(new DapperApplicationContext())))
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