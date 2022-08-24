using Dapper;

namespace OrmBenchmarks.Dapper.Migrations;

public class Database
{
    private readonly ApplicationContext _context;

    public Database(ApplicationContext context)
    {
        _context = context;
    }

    public void CreateDatabase(string dbName)
    {
        //var query = "SELECT * FROM sys.databases WHERE name = @name";
        //var parameters = new DynamicParameters();
        //parameters.Add("name", dbName);

        using var connection = _context.CreateMasterConnection();
        connection.Open();
        
        var cmd = connection.CreateCommand();

        cmd.CommandText = "DROP TABLE IF EXISTS users";
        cmd.ExecuteNonQuery();
            
        //var records = connection.Query(query, parameters);
        //if (!records.Any())
        //connection.Execute($"CREATE DATABASE {dbName}");
    }
}