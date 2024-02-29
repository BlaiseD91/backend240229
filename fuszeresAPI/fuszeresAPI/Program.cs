using fuszeresAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<FuszeresAdatbazis>(
    o=>o.UseMySql("SERVER=127.0.0.1;USER=root;PASSWORD=;DATABASE=fuszeresadatbazis;")
    );

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
