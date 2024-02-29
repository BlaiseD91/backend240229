using fuszeresAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ServerVersion sv = ServerVersion.AutoDetect("SERVER=127.0.0.1;USER=root;PASSWORD=;");
builder.Services.AddDbContext<FuszeresAdatbazis>(
    o => o.UseMySql("SERVER=127.0.0.1;USER=root;PASSWORD=;DATABASE=fuszeresadatbazis;", sv)
    );

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
