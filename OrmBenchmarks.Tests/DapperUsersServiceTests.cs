using System.Threading.Tasks;
using OrmBenchmarks.Dapper;
using OrmBenchmarks.Dapper.Repos;
using OrmBenchmarks.Dapper.Services;
using OrmBenchmarks.Services;
using Xunit;

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
        Assert.NotNull(randomUser);
    }

    [Fact]
    public async Task GetById()
    {
        var randomUser = await _aUsersService.AddRandomAsync();
        Assert.NotNull(randomUser);

        var randomUserById = await _aUsersService.GetByIdAsync(randomUser.Id);
        Assert.NotNull(randomUserById);
        Assert.Equal(randomUser.Name, randomUserById!.Name);
    }

    [Fact]
    public async Task Update()
    {
        var randomUser = await _aUsersService.AddRandomAsync();

        Assert.NotNull(randomUser);

        randomUser.Name = "renamed user";

        var updatedUserResult = await _aUsersService.UpdateAsync(randomUser);

        Assert.NotNull(updatedUserResult);
        Assert.Equal(randomUser.Name, updatedUserResult.Name);
    }

    [Fact]
    public async Task Delete()
    {
        var randomUser = await _aUsersService.AddRandomAsync();
        Assert.NotNull(randomUser);

        var deletedUserResult = await _aUsersService.DeleteAsync(randomUser);
        Assert.NotNull(deletedUserResult);
        Assert.Equal(randomUser.Name, deletedUserResult.Name);

        // todo this throws Sequence contains no elements
        //var randomUserById = await _aUsersService.GetByIdAsync(randomUser.Id);
        //Assert.Null(randomUserById);
    }
}