namespace WebApi.Helpers;

using System.Data;
using Dapper;
using Microsoft.Data.Sqlite;

public class DataContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IDbConnection CreateConnection()
    {
        return new SqliteConnection(Configuration.GetConnectionString("WebApiDatabase"));
    }

    public async Task Init()
    {
        // create database tables if they don't exist
        using var connection = CreateConnection();
        await _initShips();

        async Task _initShips()
        {
            var sql = """
                CREATE TABLE IF NOT EXISTS 
                Ships (
                    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                    Name TEXT,
                    Length INTEGER,
                    Width INTEGER,
                    Code TEXT
                );
            """;
            await connection.ExecuteAsync(sql);
        }
    }
}