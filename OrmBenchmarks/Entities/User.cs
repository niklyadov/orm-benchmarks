using OrmBenchmarks.Entities.Abstract;

namespace OrmBenchmarks.Entities;

public record User : IEntity
{
    public string Name { get; set; }
    public uint Age { get; set; }
    public long Id { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedDateTime { get; set; }
}