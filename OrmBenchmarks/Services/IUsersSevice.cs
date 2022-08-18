using OrmBenchmarks.Entities;

namespace OrmBenchmarks.Services;

public interface IUsersSevice
{
    public User AddRandom();
    public User GetById(int id);
    public User Update(User user);
    public User Delete(User user);
}