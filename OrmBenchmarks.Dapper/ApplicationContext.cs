using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

namespace OrmBenchmarks.Dapper;

public class ApplicationContext
{
    private readonly IConfiguration _configuration;

    public ApplicationContext(IConfiguration configuration)
    {
        _configuration = configuration;
        
    }

    public IDbConnection CreateMasterConnection()
        => new SqliteConnection(_configuration.GetConnectionString("MasterConnection"));
}