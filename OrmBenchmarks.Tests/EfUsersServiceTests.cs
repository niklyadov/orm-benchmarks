using System;
using System.Linq;
using System.Threading.Tasks;
using OrmBenchmarks.EF;
using OrmBenchmarks.EF.Repos;
using OrmBenchmarks.EF.Services;
using OrmBenchmarks.Entities;
using OrmBenchmarks.Services;
using Xunit;

namespace OrmBenchmarks.Tests;

public class EfUsersServiceTests
{
    private readonly IUsersService _usersService;
    private readonly ApplicationContext _context = new();
    
    public EfUsersServiceTests()
    {
        var repository = new UsersRepository(_context);
        _usersService = new UsersService(repository);
    }

    [Fact]
    public async Task AddRandom()
    {
        var randomUser = await _usersService.AddRandomAsync();
        var userInDb = _context.Users.FirstOrDefault(u => u.Id == randomUser.Id);
        
        Assert.NotNull(userInDb);
        Assert.Equal(userInDb!.Name, randomUser.Name);
    }

    [Fact]
    public async Task GetById()
    {
        var randomUser = await _usersService.AddRandomAsync();
        var userById = await _usersService.GetByIdAsync(randomUser.Id);
        
        Assert.NotNull(userById);
        Assert.Equal(userById!.Name, randomUser.Name);
    }

    [Fact]
    public async Task UpdateWithTracking()
    {
        var randomUser = await _usersService.AddRandomAsync();
        randomUser.Name = "abcd";
        
        var userInDb = _context.Users.FirstOrDefault(u => u.Id == randomUser.Id);
        
        Assert.NotNull(userInDb);
        Assert.Equal(userInDb!.Name, randomUser.Name);
    }
    
    [Fact]
    public async Task Update()
    {
        var randomUser = await _usersService.AddRandomAsync();
        randomUser.Name = "abcd";
        randomUser = await _usersService.UpdateAsync(randomUser);
        
        var userInDb = _context.Users.FirstOrDefault(u => u.Id == randomUser.Id);
        
        Assert.NotNull(userInDb);
        Assert.Equal(userInDb!.Name, randomUser.Name);
    }

    [Fact]
    public async Task<User> Delete()
    {
        var randomUser = await _usersService.AddRandomAsync();
        var deletedUser = await _usersService.DeleteAsync(randomUser);
        
        var deletedUserInDb = _context.Users.FirstOrDefault(u => u.Id == deletedUser.Id);
        
        Assert.True(deletedUser.IsDeleted);
        
        Assert.NotNull(deletedUserInDb);
        Assert.True(deletedUserInDb!.IsDeleted);

        return deletedUser;
    }
    
    [Fact]
    public async Task<User> DeleteWithTracking()
    {
        var randomUser = await _usersService.AddRandomAsync();
        await _usersService.DeleteAsync(randomUser);
        
        var deletedUserInDb = _context.Users.FirstOrDefault(u => u.Id == randomUser.Id);
        
        Assert.True(randomUser.IsDeleted);
        Assert.True(deletedUserInDb!.IsDeleted);
        
        Assert.NotNull(deletedUserInDb);

        return randomUser;
    }
}