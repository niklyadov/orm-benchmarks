using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using Perfolizer.Horology;

BenchmarkRunner.Run(typeof(Program).Assembly, new Config());

internal class Config : ManualConfig
{
    public Config()
    {
        Add(new Job("MySuperJob", RunMode.Short)
        {
            Run = { LaunchCount = 5, IterationTime = TimeInterval.Millisecond * 200 }
        });
        Add(DefaultConfig.Instance.GetExporters().ToArray());
        Add(DefaultConfig.Instance.GetLoggers().ToArray());
        Add(DefaultConfig.Instance.GetColumnProviders().ToArray());
    }
}