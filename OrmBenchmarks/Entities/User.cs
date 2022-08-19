using OrmBenchmarks.Entities.Abstract;

namespace OrmBenchmarks.Entities;

public record User : IEntity
{
    public long Id { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedDateTime { get; set; }
    public string Name { get; set; }
    public uint Age { get; set; }
}