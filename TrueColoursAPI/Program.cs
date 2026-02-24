using Microsoft.EntityFrameworkCore;
using TrueColoursAPI;
using TrueColoursAPI.Data;
using TrueColoursAPI.Managers;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddScoped<IColourManager, ColourManager>();
builder.Services.AddScoped<IColourTypeManager, ColourTypeManager>();
builder.Services.AddScoped<ISyncManager, SyncManager>();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

builder.Services.AddCors(c =>
{
    c.AddPolicy(
        name: "AllowOrigin",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .WithExposedHeaders("X-Count");
        });
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "True Colours API V1");
    c.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("AllowOrigin");

app.MapControllers();

// Seed database
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    SeedData.SeedDatabase(context);
}

app.Run();

namespace TrueColoursAPI
{
    public partial class Program { }
}
