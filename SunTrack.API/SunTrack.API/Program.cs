using Microsoft.EntityFrameworkCore;
using SunTrack.API;
using SunTrack.API.Data;
using SunTrack.API.Data.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddMyDependencyGroup();
builder.Services.AddDbContext<SunTrackContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SunTrackConnection"))
);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

namespace SunTrack.API.Data
{
    using Microsoft.EntityFrameworkCore;

    public class SunTrackDBContext : DbContext
    {
        public SunTrackDBContext(DbContextOptions<SunTrackDBContext> options)
            : base(options)
        {
        }
    }
}
