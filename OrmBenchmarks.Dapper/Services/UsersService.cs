using OrmBenchmarks.Dapper.Repos;
using OrmBenchmarks.Entities;
using OrmBenchmarks.Services;

namespace OrmBenchmarks.Dapper.Services;

public class UsersService : AUsersService
{
    private readonly UsersRepository _repository;
    public UsersService(UsersRepository repository)
    {
        _repository = repository;
    }
    
    public override async Task<User> AddRandomAsync()
    {
        var user = GenerateRandomUser();

        return await _repository.Add(user);
    }

    public override Task<User?> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public override Task<User> UpdateAsync(User user)
    {
        throw new NotImplementedException();
    }

    public override Task<User> DeleteAsync(User user)
    {
        throw new NotImplementedException();
    }
}