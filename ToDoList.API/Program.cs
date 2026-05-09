using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using ToDoList.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql
    (builder.Configuration.GetConnectionString("Default")?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")));
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();



app.MapScalarApiReference();

app.Run();

