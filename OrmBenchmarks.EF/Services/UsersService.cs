using OrmBenchmarks.EF.Repos;
using OrmBenchmarks.Entities;
using OrmBenchmarks.Services;

namespace OrmBenchmarks.EF.Services;

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

    public override Task<User> UpdateRandomAsync(User user)
    {
        var randomGeneratedUser = GenerateRandomUser();

        user.Age = randomGeneratedUser.Age;
        user.Name = randomGeneratedUser.Name;

        return UpdateAsync(randomGeneratedUser);
    }

    public override async Task<User> DeleteAsync(User user)
    {
        return await _repository.Delete(user);
    }

    public override async Task<User> RestoreAsync(User user)
    {
        return await _repository.Restore(user);
    }
}