using OrmBenchmarks.Entities;
using OrmBenchmarks.Services;

namespace OrmBenchmarks.Dapper.Services;

public class UsersService : IUsersService
{
    public Task<User> AddRandomAsync()
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<User> DeleteAsync(User user)
    {
        throw new NotImplementedException();
    }
}