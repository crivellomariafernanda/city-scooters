using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection")
        ?? throw new InvalidOperationException("Connection string"
        + "'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure Swagger in the request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Minimal API v1");
    });
}

app.MapGet("/scooter-list", async (ApplicationDbContext db) =>
    await db.Scooters.ToListAsync());

app.MapGet("/station-list", async (ApplicationDbContext db) =>
    await db.Stations.ToListAsync());

//app.MapGet("/station-list/complete", async (ApplicationDbContext db) =>
//    await db.Todos.Where(t => t.IsComplete).ToListAsync());

//app.MapGet("/todoitems/{id}", async (int id, ApplicationDbContext db) =>
//    await db.Todos.FindAsync(id)
//        is Todo todo
//            ? Results.Ok(todo)
//            : Results.NotFound());

//app.MapPost("/todoitems", async (Todo todo, ApplicationDbContext db) =>
//{
//    db.Todos.Add(todo);
//    await db.SaveChangesAsync();
//
//    return Results.Created($"/todoitems/{todo.Id}", todo);
//});
//
//app.MapPut("/todoitems/{id}", async (int id, Todo inputTodo, ApplicationDbContext db) =>
//{
//    var todo = await db.Todos.FindAsync(id);
//
//    if (todo is null) return Results.NotFound();
//
//    todo.Name = inputTodo.Name;
//    todo.IsComplete = inputTodo.IsComplete;
//
//    await db.SaveChangesAsync();
//
//    return Results.NoContent();
//});

//app.MapDelete("/todoitems/{id}", async (int id, ApplicationDbContext db) =>
//{
//    if (await db.Todos.FindAsync(id) is Todo todo)
//    {
//        db.Todos.Remove(todo);
//        await db.SaveChangesAsync();
//        return Results.NoContent();
//    }
//
//    return Results.NotFound();
//});

app.Run();


