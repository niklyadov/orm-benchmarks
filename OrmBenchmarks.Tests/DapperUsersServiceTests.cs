using System;
using OrmBenchmarks.Dapper.Services;
using OrmBenchmarks.Entities;
using OrmBenchmarks.Services;
using Xunit;

namespace OrmBenchmarks.Tests;

public class DapperUsersServiceTests
{
    private readonly IUsersService _usersService;
    
    public DapperUsersServiceTests()
    {
        _usersService = new UsersService();
    }
    
    [Fact]
    public void AddRandom()
    {
        Assert.Throws<NotImplementedException>(() =>
        {
            _usersService.AddRandomAsync();
        });
    }

    [Fact]
    public void GetById()
    {
        Assert.Throws<NotImplementedException>(() =>
        {
            _usersService.GetByIdAsync(0);
        });
    }

    [Fact]
    public void Update()
    {
        Assert.Throws<NotImplementedException>(() =>
        {
            _usersService.UpdateAsync(new User());
        });
    }

    [Fact]
    public void Delete()
    {
        Assert.Throws<NotImplementedException>(() =>
        {
            _usersService.DeleteAsync(new User());
        });
    }
}