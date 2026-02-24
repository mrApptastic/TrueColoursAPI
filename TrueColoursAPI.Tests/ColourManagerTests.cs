using AutoMapper;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using TrueColoursAPI.Data;
using TrueColoursAPI.Managers;
using TrueColoursAPI.Models;

namespace TrueColoursAPI.Tests;

public class ColourManagerTests : IDisposable
{
    private readonly SqliteConnection _connection;
    private readonly ApplicationDbContext _context;
    private readonly ColourManager _manager;

    public ColourManagerTests()
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
            cfg.AddProfile<ColourProfile>();
            cfg.AddProfile<ColourTypeProfile>();
        });
        var mapper = config.CreateMapper();

        var logger = NullLogger<ColourManager>.Instance;
        _manager = new ColourManager(logger, mapper, _context);

        SeedTestData();
    }

    private void SeedTestData()
    {
        var type = new ColourType { Name = "TestType", Description = "Test category" };
        _context.TrueTypes.Add(type);

        _context.TrueColours.AddRange(
            new Colour { Name = "Red", Red = 255, Green = 0, Blue = 0, Description = "Pure Red", ColourType = type },
            new Colour { Name = "Green", Red = 0, Green = 255, Blue = 0, Description = "Pure Green", ColourType = type },
            new Colour { Name = "Blue", Red = 0, Green = 0, Blue = 255, Description = "Pure Blue", ColourType = type },
            new Colour { Name = "White", Red = 255, Green = 255, Blue = 255, Description = "Pure White", ColourType = type },
            new Colour { Name = "Black", Red = 0, Green = 0, Blue = 0, Description = "Pure Black", ColourType = type }
        );

        _context.SaveChanges();
    }

    [Fact]
    public async Task GetNearestRGB_ReturnsCorrectCount()
    {
        var results = await _manager.GetNearestRGB(255, 0, 0, take: 3);
        Assert.Equal(3, results.Count);
    }

    [Fact]
    public async Task GetNearestRGB_ReturnsRedFirst_WhenSearchingRed()
    {
        var results = await _manager.GetNearestRGB(255, 0, 0, take: 1);
        var first = results.First();
        Assert.Equal("Red", first.Name);
    }

    [Fact]
    public async Task GetNearestHex_ReturnsHexFormat()
    {
        var results = await _manager.GetNearestHex(255, 0, 0, take: 1);
        var first = results.First();
        Assert.Equal("#FF0000", first.Hex);
    }

    [Fact]
    public async Task GetNearestHSL_ReturnsHSLFormat()
    {
        var results = await _manager.GetNearestHSL(255, 0, 0, take: 1);
        var first = results.First();
        Assert.StartsWith("hsl(", first.HSL);
    }

    [Fact]
    public async Task GetNearestCMYK_ReturnsCMYKFormat()
    {
        var results = await _manager.GetNearestCMYK(255, 0, 0, take: 1);
        var first = results.First();
        Assert.StartsWith("CMYK(", first.CMYK);
    }

    [Fact]
    public async Task SearchRGBColours_FindsByName()
    {
        var searchDto = new ColourSearchModel { Name = "Red" };
        var result = await _manager.SearchRGBColours(searchDto, page: 1, take: 50);
        Assert.Single(result.results);
        Assert.Equal(1, result.count);
        Assert.Equal("Red", result.results.First().Name);
    }

    [Fact]
    public async Task SearchRGBColours_ReturnsAll_WhenNoFilter()
    {
        var searchDto = new ColourSearchModel { };
        var result = await _manager.SearchRGBColours(searchDto, page: 1, take: 50);
        Assert.Equal(5, result.count);
    }

    [Fact]
    public async Task SearchHexColours_FindsByPartialName()
    {
        var searchDto = new ColourSearchModel { Name = "bl" };
        var result = await _manager.SearchHexColours(searchDto, page: 1, take: 50);
        Assert.Equal(2, result.count); // Blue and Black
    }

    [Fact]
    public async Task SearchRGBColours_Pagination_Works()
    {
        var searchDto = new ColourSearchModel { };
        var result = await _manager.SearchRGBColours(searchDto, page: 1, take: 2);
        Assert.Equal(2, result.results.Count);
        Assert.Equal(5, result.count);
    }

    [Fact]
    public async Task GetNearestRGB_ReturnsCategory()
    {
        var results = await _manager.GetNearestRGB(255, 0, 0, take: 1);
        Assert.Equal("TestType", results.First().Category);
    }

    public void Dispose()
    {
        _context.Dispose();
        _connection.Dispose();
    }
}
