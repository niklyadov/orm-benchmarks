using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using OrmBenchmarks.Benchmarks.Scenarios;

var summary = BenchmarkRunner.Run(typeof(Program).Assembly);

public class DapperVsEntityFramework
{
    public DapperVsEntityFramework()
    {
        Console.WriteLine("Call");
    }

    [Benchmark]
    public void Dapper()
    {
        Task.Run(async () =>
        {
            await new DapperUsersScenario().DoAsync();
        });
    }
    
    [Benchmark]
    public void EntityFramework()
    {
        Task.Run(async () =>
        {
            await new EfUsersScenario().DoAsync();
        });
    }
}
