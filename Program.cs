using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net;
using ToDoList;
using System;

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

app.MapPost("/new", async (HttpRequest request) =>
{
    var item = await request.ReadFromJsonAsync<TodoItem?>();
    if (item != null)
    {
        repo.AddNew(new TodoItem(repo.Items.Count, item.Title, DateTime.Now));
        return Results.Ok(item.ToString());
    }
    else
    {
        return Results.NoContent();
    }
});

app.Run();
