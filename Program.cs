using Microsoft.AspNetCore.Builder;
using System.Net;
using ToDoList;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var repo = new TodoRepo();

app.MapGet("/", () => repo.Items);
app.MapGet("/seed={i:int}", (int i) => repo.Seed(i));
app.MapGet("/{id:int}", (int id) => {
    if(repo.Items.Any(x => x.Id == id))
    {
        return Results.Ok(repo.Items.First(x => x.Id == id));
    } else
    {
        return Results.NotFound("ToDo Item not found.");
    }
});

app.Run();
