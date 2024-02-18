using System.Diagnostics;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Personalverwaltung.Office.Infrastructure;

namespace Personalverwaltung.Office.Core.Tests;

public class DatabaseTest : IDisposable
{
    private readonly SqliteConnection _connection;
    protected readonly OfficeContext _db;

    public DatabaseTest()
    {
        _connection = new SqliteConnection("Datasource=:memory:");
        _connection.Open();

        var opt = new DbContextOptionsBuilder()
            .UseSqlite(_connection)
            .LogTo(message => Debug.WriteLine(message), Microsoft.Extensions.Logging.LogLevel.Information)
            .EnableSensitiveDataLogging()
            .Options;
        
        _db = new OfficeContext(opt);
    }

    public void Dispose()
    {
        _db.Dispose();
        _connection.Dispose();
    }
}