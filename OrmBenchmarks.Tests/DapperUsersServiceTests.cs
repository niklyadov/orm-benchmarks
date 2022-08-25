using System;
using System.Linq;
using System.Threading.Tasks;
using OrmBenchmarks.Dapper;
using OrmBenchmarks.Dapper.Repos;
using OrmBenchmarks.Dapper.Services;
using OrmBenchmarks.EF;
using OrmBenchmarks.Entities;
using OrmBenchmarks.Services;
using Xunit;
using UsersService = OrmBenchmarks.Dapper.Services.UsersService;

namespace OrmBenchmarks.Tests;

public class DapperUsersServiceTests
{
    private readonly AUsersService _aUsersService;
    //private readonly EfApplicationContext _contextEf = new();
    
    public DapperUsersServiceTests()
    {
        var repository = new UsersRepository(new DapperApplicationContext());
        _aUsersService = new UsersService(repository);
    }
    
    [Fact]
    public async Task AddRandom()
    {
        var randomUser = await _aUsersService.AddRandomAsync();
        //var userInDb = _contextEf.Users.FirstOrDefault(u => u.Id == randomUser.Id);
        
        Assert.NotNull(randomUser);
        //Assert.NotNull(userInDb);
        //Assert.Equal(userInDb!.Name, randomUser.Name);
    }

    [Fact]
    public void GetById()
    {
        Assert.Throws<NotImplementedException>(() =>
        {
            _aUsersService.GetByIdAsync(0);
        });
    }

    [Fact]
    public void Update()
    {
        Assert.Throws<NotImplementedException>(() =>
        {
            _aUsersService.UpdateAsync(new User());
        });
    }

    [Fact]
    public void Delete()
    {
        Assert.Throws<NotImplementedException>(() =>
        {
            _aUsersService.DeleteAsync(new User());
        });
    }
}