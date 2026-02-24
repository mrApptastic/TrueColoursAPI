using AutoMapper;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using TrueColoursAPI.Data;
using TrueColoursAPI.Managers;
using TrueColoursAPI.Models;

namespace TrueColoursAPI.Tests;

public class ColourTypeManagerTests : IDisposable
{
    private readonly SqliteConnection _connection;
    private readonly ApplicationDbContext _context;
    private readonly ColourTypeManager _manager;

    public ColourTypeManagerTests()
    {
        _connection = new SqliteConnection("DataSource=:memory:");
        _connection.Open();

        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlite(_connection)
            .Options;

        _context = new ApplicationDbContext(options);
        _context.Database.EnsureCreated();

        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ColourTypeProfile>();
        });
        var mapper = config.CreateMapper();

        var logger = NullLogger<ColourTypeManager>.Instance;
        _manager = new ColourTypeManager(logger, mapper, _context);
    }

    [Fact]
    public async Task GetAll_ReturnsEmpty_WhenNoData()
    {
        var result = await _manager.GetAll();
        Assert.Empty(result);
    }

    [Fact]
    public async Task GetAll_ReturnsAllTypes()
    {
        _context.TrueTypes.AddRange(
            new ColourType { Name = "HTML", Description = "HTML Colours" },
            new ColourType { Name = "Werner's", Description = "Werner's Colours" }
        );
        await _context.SaveChangesAsync();

        var result = await _manager.GetAll();
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public async Task GetAll_ReturnsOrderedByName()
    {
        _context.TrueTypes.AddRange(
            new ColourType { Name = "Zebra", Description = "Z type" },
            new ColourType { Name = "Alpha", Description = "A type" }
        );
        await _context.SaveChangesAsync();

        var result = await _manager.GetAll();
        Assert.Equal("Alpha", result.First().Name);
        Assert.Equal("Zebra", result.Last().Name);
    }

    [Fact]
    public async Task GetAll_ReturnsPublicId()
    {
        _context.TrueTypes.Add(new ColourType { Name = "Test", Description = "Test" });
        await _context.SaveChangesAsync();

        var result = await _manager.GetAll();
        Assert.NotNull(result.First().PublicId);
        Assert.NotEmpty(result.First().PublicId);
    }

    public void Dispose()
    {
        _context.Dispose();
        _connection.Dispose();
    }
}
