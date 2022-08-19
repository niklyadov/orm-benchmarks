using OrmBenchmarks.EF.Repos;
using OrmBenchmarks.Entities;
using OrmBenchmarks.Services;

namespace OrmBenchmarks.EF.Services;

public class UsersService : IUsersService
{
    private readonly UsersRepository _repository;
    public UsersService(UsersRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<User> AddRandomAsync()
    {
        var user = GenerateRandomUser();

        return await _repository.Add(user);
    }

    private User GenerateRandomUser()
    {
        var random = new Random();

        return new User
        {
            Age = (uint)random.Next(100),
            Name = Guid.NewGuid().ToString()
        };
    }

    public async Task<User?> GetByIdAsync(long id)
    {
        return await _repository.GetById(id);
    }

    public async Task<User> UpdateAsync(User user)
    {
        return await _repository.Update(user);
    }

    public async Task<User> DeleteAsync(User user)
    {
        return await _repository.Delete(user);
    }
}