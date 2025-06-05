using DataPipeline.Extensions;
using DataPipeline.Models;
using DataPipeline.Seeds;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DbAppContext>(options => options.UseSqlServer(builder.Configuration["ConnectionString:WebApiDatabase"]));
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddDataConfig();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.IsDevOrStaging())
{
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<DbAppContext>();
        await AppDbSeeder.SeedAsync(context);
    }
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
