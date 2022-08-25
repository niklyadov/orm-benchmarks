using System.Data;
using Microsoft.Data.Sqlite;

namespace OrmBenchmarks.Dapper;

public class DapperApplicationContext
{
    public static readonly string ConnectionString = "Data Source=/dappertest.db";
    public IDbConnection CreateConnection()
    {
        var connection = new SqliteConnection(ConnectionString);
        //connection.Open();

        return connection;
    }
}