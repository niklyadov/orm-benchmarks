using Dapper;
using OrmBenchmarks.Entities;

namespace OrmBenchmarks.Dapper.Repos;

public class UsersRepository
{
    private DapperApplicationContext _context;
    public UsersRepository(DapperApplicationContext context)
    {
        _context = context;
    }
    
    public async Task<User> Add(User user)
    {
        using var connection = _context.CreateConnection();
        
        await connection.ExecuteAsync("INSERT INTO Users (Name, Age, IsDeleted) VALUES (@Name, @Age, @IsDeleted);", user);
        var id = await connection.QuerySingleAsync<long>("SELECT last_insert_rowid();");
        
        return await GetById(id);
    }

    public async Task<User> GetById(long id)
    {
        using var connection = _context.CreateConnection();

        return await connection.QuerySingleAsync<User>("SELECT * FROM Users u WHERE u.Id = @Id;", new {Id = id});
    }

    public async Task<User> Update(User user)
    {
        using var connection = _context.CreateConnection();
        
        throw new NotImplementedException();
    }

    public async Task<User> Delete(User user)
    {
        using var connection = _context.CreateConnection();

        await connection.ExecuteAsync("");
        throw new NotImplementedException();
    }
}