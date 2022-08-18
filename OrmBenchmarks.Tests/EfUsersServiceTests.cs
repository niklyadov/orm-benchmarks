using System;
using OrmBenchmarks.EF.Services;
using OrmBenchmarks.Entities;
using OrmBenchmarks.Services;
using Xunit;

namespace OrmBenchmarks.Tests;

public class EfUsersServiceTests
{
    private IUsersSevice _usersSevice;
    
    public EfUsersServiceTests()
    {
        _usersSevice = new UsersService();
    }
    
    [Fact]
    public void AddRandom()
    {
        Assert.Throws<NotImplementedException>(() =>
        {
            _usersSevice.AddRandom();
        });
    }

    [Fact]
    public void GetById()
    {
        Assert.Throws<NotImplementedException>(() =>
        {
            _usersSevice.GetById(0);
        });
    }

    [Fact]
    public void Update()
    {
        Assert.Throws<NotImplementedException>(() =>
        {
            _usersSevice.Update(new User());
        });
    }

    [Fact]
    public void Delete()
    {
        Assert.Throws<NotImplementedException>(() =>
        {
            _usersSevice.Delete(new User());
        });
    }
}