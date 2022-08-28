using Microsoft.EntityFrameworkCore;
using OrmBenchmarks.Entities;

namespace OrmBenchmarks.EF;

public class EfApplicationContext : DbContext
{
    public EfApplicationContext()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    public DbSet<User> Users { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=ef-benchmark.db");
    }
}