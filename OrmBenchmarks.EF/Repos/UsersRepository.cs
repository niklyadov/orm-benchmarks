using OrmBenchmarks.EF.Repos.Abstract;
using OrmBenchmarks.Entities;

namespace OrmBenchmarks.EF.Repos;

public class UsersRepository : BaseRepository<User, ApplicationContext>
{
    public UsersRepository(ApplicationContext context) : base(context)
    {
    }
}