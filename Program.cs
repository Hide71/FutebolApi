using FutebolApi.Data;
using FutebolApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=Futebol.db"));
var app = builder.Build();

app.MapGet("/times", async (AppDbContext db) =>
{
   return await db.Times.ToListAsync();
});
app.MapGet("times/{id}", async (int id, AppDbContext db) =>
{
    var time = await db.Times.FindAsync(id);
     return time is not null ? Results.Ok(time) : Results.NotFound("time não foi encontrado"); 
});
app.MapPost("/times", async (AppDbContext db, Time novoTime) =>
{
     db.Times.Add(novoTime);
     await db.SaveChangesAsync();
     return Results.Created($" O time {novoTime.Nome} foi criado com sucesso", novoTime);
});
app.MapPut("/times/{id}", async (int id, AppDbContext db, Time timeAtualizado) =>
{
    var time = await db.Times.FindAsync(id);
    if(time is null) 
    {
        return Results.NotFound("Time não foi encontrado");
    }
    time.Nome = timeAtualizado.Nome;
    time.Cidade = timeAtualizado.Cidade;
    time.Brasileiros = timeAtualizado.Brasileiros;
    time.Mundiais = timeAtualizado.Mundiais;
    await db.SaveChangesAsync();
    return Results.Ok(time);
});
app.MapDelete("/times/{id}", async (int id, AppDbContext db) =>
{
    var time = db.Times.Find(id);
    if (time is null)
    {
        return Results.NotFound("Time não foi encontrado");
    }
    db.Times.Remove(time);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();
