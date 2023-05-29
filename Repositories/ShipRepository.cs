namespace WebApi.Repositories;

using Dapper;
using WebApi.Entities;
using WebApi.Helpers;

public interface IShipRepository
{
    Task<IEnumerable<Ship>> GetAll();
    Task<Ship> GetById(int id);
    Task Create(Ship ship);
    Task Update(Ship ship);
    Task Delete(int id);
    Task<Ship> GetByCode(string code);
}

public class ShipRepository : IShipRepository
{
    private DataContext _context;

    public ShipRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Ship>> GetAll()
    {
        using var connection = _context.CreateConnection();
        var sql = """
            SELECT * FROM Ships
        """;
        return await connection.QueryAsync<Ship>(sql);
    }

    public async Task<Ship> GetById(int id)
    {
        using var connection = _context.CreateConnection();
        var sql = """
            SELECT * FROM Ships 
            WHERE Id = @id
        """;
        return await connection.QuerySingleOrDefaultAsync<Ship>(sql, new { id });
    }

    public async Task Create(Ship ship)
    {
        using var connection = _context.CreateConnection();
        var sql = """
            INSERT INTO Ships (Name, Length, Width, Code)
            VALUES (@Name, @Length, @Width, @Code)
        """;
        await connection.ExecuteAsync(sql, ship);
    }

    public async Task Update(Ship ship)
    {
        using var connection = _context.CreateConnection();
        var sql = """
            UPDATE Ships 
            SET Name = @Name,
                Length = @Length,
                Width = @Width, 
                Code = @Code
            WHERE Id = @Id
        """;
        await connection.ExecuteAsync(sql, ship);
    }

    public async Task Delete(int id)
    {
        using var connection = _context.CreateConnection();
        var sql = """
            DELETE FROM Ships 
            WHERE Id = @id
        """;
        await connection.ExecuteAsync(sql, new { id });
    }

    public async Task<Ship> GetByCode(string code)
    {
        using var connection = _context.CreateConnection();
        var sql = """
            SELECT * FROM Ships 
            WHERE Code = @code
        """;
        return await connection.QuerySingleOrDefaultAsync<Ship>(sql, new { code });
    }

}