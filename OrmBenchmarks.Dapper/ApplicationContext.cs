using System.Data;
using Microsoft.Data.Sqlite;

namespace OrmBenchmarks.Dapper;

public class ApplicationContext : IDisposable
{
    public readonly IDbConnection DbConnection;
    
    public ApplicationContext()
    {
        DbConnection = new SqliteConnection("Data Source=dapper.db");
        DbConnection.Open();
    }

    public void RecreateTables()
    {

        var cmd = DbConnection.CreateCommand();

        cmd.CommandText = "DROP TABLE IF EXISTS users";
        cmd.ExecuteNonQuery();

        //cmd.CommandText = @"CREATE TABLE users(id INTEGER PRIMARY KEY, name TEXT, age INT)";
        //cmd.ExecuteNonQuery();
    }
    
    public void Dispose()
    {
        DbConnection.Close();
        DbConnection.Dispose();
    }
}