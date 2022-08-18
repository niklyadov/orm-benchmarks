namespace OrmBenchmarks.Entities;

public record User()
{
    public int Id { get; set; }
    public string Name { get; set; }
    public uint Age { get; set; }
}