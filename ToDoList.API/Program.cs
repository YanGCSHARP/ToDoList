using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using ToDoList.API.Features.Rooms;       // ← добавь
using ToDoList.API.Features.ToDoItems;
using ToDoList.Infrastructure.Persistence;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true); // ← перенеси сюда

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(
    builder.Configuration.GetConnectionString("Default") 
    ?? throw new InvalidOperationException("Connection string not found.")));
builder.Services.AddMediatR(cfg => 
    cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapScalarApiReference();

app.MapToDoItemEndpoints();
app.MapRoomsEndpoints(); // ← добавь

app.Run();