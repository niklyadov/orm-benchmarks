using OrmBenchmarks.Entities;

namespace OrmBenchmarks.Services;

public abstract class AUsersService
{
    public abstract Task<User> AddRandomAsync();
    public abstract Task<User> GetByIdAsync(long id);
    public abstract Task<User> UpdateAsync(User user);
    public abstract Task<User> UpdateRandomAsync(User user);
    public abstract Task<User> DeleteAsync(User user);
    public abstract Task<User> RestoreAsync(User user);

    protected User GenerateRandomUser()
    {
        var random = new Random();

        return new User
        {
            Age = (uint)random.Next(100),
            Name = Guid.NewGuid().ToString()
        };
    }
}