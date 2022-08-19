using OrmBenchmarks.Entities;

namespace OrmBenchmarks.Services;

public interface IUsersService
{
    public Task<User> AddRandomAsync();
    public Task<User?> GetByIdAsync(long id);
    public Task<User> UpdateAsync(User user);
    public Task<User> DeleteAsync(User user);
}