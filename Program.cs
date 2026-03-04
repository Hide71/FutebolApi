var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/usuario", () =>
{
    List<string> Nomes = new List <string>
    {
        "João",
        "Paulo",
        "Miguel",
        "Yuri Alberto"
        
    };
    return Nomes;
});
app.MapPost("/usuario", (string nome) =>
{
    return Results.Ok($"O nome {nome} foi adicionado com sucesso");
});
app.MapPut("/usuario/{id}", (int id, string novoNome) =>
{
    return Results.Ok($"Nome de usuario id {id} alterado para {novoNome} com sucesso! ");
});
app.MapPatch("usuario/{id}", (int id, string campo, string valor ) =>
{
    return Results.Ok($" Usuario {id} teve o campo {campo} alterado para {valor} com sucesso");
});
app.MapDelete("usuario/{id}", (int id) =>
{
    return Results.Ok($"Usuario com o id {id} remmovido com sucesso");
});

app.Run();
