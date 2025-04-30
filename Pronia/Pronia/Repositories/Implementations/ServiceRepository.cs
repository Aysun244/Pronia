using Dapper;
using Microsoft.Data.SqlClient;
using Pronia_BB104.Constants;
using Pronia_BB104.Models;
using Pronia_BB104.Repositories.Abstractions;
using System.Data;

namespace Pronia_BB104.Repositories.Implementations;

public class ServiceRepository : IServiceRepository
{
    private IDbConnection _connection { get => new SqlConnection(ConnectionStrings.SqlConnectionString); }
    public async Task AddAsync(Service entity)
    {
        using var db = _connection;

        await db.ExecuteAsync("INSERT INTO Services VALUES (@Name, @Description, @ImagePath)", entity);
    }

    public async Task DeleteAsync(int id)
    {
        using var db = _connection;

        await db.ExecuteAsync("DELETE FROM Services WHERE Id = @Id", new { Id = id });
    }

    public async Task<List<Service>> GetAllAsync()
    {
        using var db = _connection;

        var list = await db.QueryAsync<Service>("SELECT * FROM Services");

        return list.ToList();
    }

    public Task<Service?> GetByIdAsync(int id)
    {
        using var db = _connection;

        var service = db.QueryFirstOrDefaultAsync<Service>("SELECT * FROM Services WHERE Id = @Id", new { Id = id });

        return service;
    }

    public Task UpdateAsync(Service entity)
    {
        using var db = _connection;
        var service = db.ExecuteAsync("UPDATE Services SET Name = @Name, Description = @Description,  ImagePath = @ImagePath WHERE Id = @Id", entity);
        return service;
    }
}
