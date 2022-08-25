using System.Linq;
using System.Threading.Tasks;
using OrmBenchmarks.EF;
using OrmBenchmarks.EF.Repos;
using OrmBenchmarks.EF.Services;
using OrmBenchmarks.Entities;
using Xunit;

namespace OrmBenchmarks.Tests;

public class EfUsersServiceTests
{
    private readonly UsersService _aUsersService;
    private readonly EfApplicationContext _context = new();
    
    public EfUsersServiceTests()
    {
        //_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        var repository = new UsersRepository(_context);
        _aUsersService = new UsersService(repository);
    }

    [Fact]
    public async Task AddRandom()
    {
        var randomUser = await _aUsersService.AddRandomAsync();
        var userInDb = _context.Users.FirstOrDefault(u => u.Id == randomUser.Id);
        
        Assert.NotNull(userInDb);
        Assert.Equal(userInDb!.Name, randomUser.Name);
    }

    [Fact]
    public async Task GetById()
    {
        var randomUser = await _aUsersService.AddRandomAsync();
        var userById = await _aUsersService.GetByIdAsync(randomUser.Id);
        
        Assert.NotNull(userById);
        Assert.Equal(userById!.Name, randomUser.Name);
    }

    [Fact]
    public async Task UpdateWithTracking()
    {
        var randomUser = await _aUsersService.AddRandomAsync();
        randomUser.Name = "abcd";
        
        var userInDb = _context.Users.FirstOrDefault(u => u.Id == randomUser.Id);
        
        Assert.NotNull(userInDb);
        Assert.Equal(userInDb!.Name, randomUser.Name);
    }
    
    [Fact]
    public async Task Update()
    {
        var randomUser = await _aUsersService.AddRandomAsync();
        randomUser.Name = "abcd";
        randomUser = await _aUsersService.UpdateAsync(randomUser);
        
        var userInDb = _context.Users.FirstOrDefault(u => u.Id == randomUser.Id);
        
        Assert.NotNull(userInDb);
        Assert.Equal(userInDb!.Name, randomUser.Name);
    }

    [Fact]
    public async Task<User> Delete()
    {
        var randomUser = await _aUsersService.AddRandomAsync();
        var deletedUser = await _aUsersService.DeleteAsync(randomUser);
        
        var deletedUserInDb = _context.Users.FirstOrDefault(u => u.Id == deletedUser.Id);
        
        Assert.True(deletedUser.IsDeleted);
        
        Assert.NotNull(deletedUserInDb);
        Assert.True(deletedUserInDb!.IsDeleted);

        return deletedUser;
    }
}