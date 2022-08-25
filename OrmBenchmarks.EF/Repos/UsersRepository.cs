using OrmBenchmarks.EF.Repos.Abstract;
using OrmBenchmarks.Entities;

namespace OrmBenchmarks.EF.Repos;

public class UsersRepository : BaseRepository<User, EfApplicationContext>
{
    public UsersRepository(EfApplicationContext context) : base(context)
    {
    }
}