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

        return await connection.QuerySingleAsync<User>("SELECT * FROM Users u WHERE u.Id = @Id AND u.IsDeleted = false;", new {Id = id});
    }
    
    public async Task<User> GetByIdDeletedAlso(long id)
    {
        using var connection = _context.CreateConnection();

        return await connection.QuerySingleAsync<User>("SELECT * FROM Users u WHERE u.Id = @Id;", new {Id = id});
    }

    public async Task<User> Update(User user)
    {
        using var connection = _context.CreateConnection();

        await connection.ExecuteAsync("UPDATE Users set Name = @Name, Age = @Age, IsDeleted = @IsDeleted, DeletedDateTime = @DeletedDateTime" +
                                      " WHERE Users.Id = @Id AND Users.IsDeleted = false;", user);

        return await GetByIdDeletedAlso(user.Id);
    }

    public async Task<User> Delete(User user)
    {

        user.IsDeleted = true;
        user.DeletedDateTime = DateTime.UtcNow;
        
        return await Update(user);
    }
    
    public async Task<User> Restore(User user)
    {

        user.IsDeleted = false;
        user.DeletedDateTime = null;
        
        return await Update(user);
    }
}