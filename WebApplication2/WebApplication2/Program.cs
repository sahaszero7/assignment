using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Model;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<workdb>(opt => opt.UseInMemoryDatabase(databaseName: "work"));
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

app.MapGet("/workitems", async (workdb db) =>
    await db.works.ToListAsync());

app.MapGet("/workitems/{id}", async (int id, workdb db) =>
    await db.works.FindAsync(id)
        is work workItem
            ? Results.Ok(workItem)
            : Results.NotFound());

app.MapPost("/workitems", async (work workItem, workdb db) =>
{
    db.works.Add(workItem);
    await db.SaveChangesAsync();

    return Results.Created($"/workitems/{workItem.Id}", workItem);
});

app.MapPut("/workitems/{id}", async (int id, work inputWorkItem, workdb db) =>
{
    var workItem = await db.works.FindAsync(id);

    if (workItem is null) return Results.NotFound();

    workItem.Title = inputWorkItem.Title;
    workItem.Description = inputWorkItem.Description;
    workItem.dueDate = inputWorkItem.dueDate;
    workItem.Status = inputWorkItem.Status;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/workitems/{id}", async (int id, workdb db) =>
{
    if (await db.works.FindAsync(id) is work workItem)
    {
        db.works.Remove(workItem);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }

    return Results.NotFound();
});

app.Run();
