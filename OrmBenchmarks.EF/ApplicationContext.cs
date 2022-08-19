using Microsoft.EntityFrameworkCore;
using OrmBenchmarks.Entities;

namespace OrmBenchmarks.EF;

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;

    public ApplicationContext()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=ef-benchmark.db");
    }
}