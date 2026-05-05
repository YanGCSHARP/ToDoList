using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Entities;

namespace ToDoList.Infrastructure.Persistence;

public class AppDbContext : DbContext{
    
    public AppDbContext (DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Room> Rooms => Set<Room>();
    public DbSet<TodoItem> TodoItems => Set<TodoItem>();
    public DbSet<UserRoom> UserRooms => Set<UserRoom>();
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
    
}