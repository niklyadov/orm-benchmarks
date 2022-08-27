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

    public override async Task<User?> GetByIdAsync(long id)
    {
        return await _repository.GetById(id);
    }

    public override async Task<User> UpdateAsync(User user)
    {
        return await _repository.Update(user);
    }

    public override async Task<User> DeleteAsync(User user)
    {
        return await _repository.Delete(user);
    }
}